using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BusDataCollector.Components
{
	public delegate void BetterDoWorkEventHandler(object sender, BetterDoWorkEventArgs args);
	public delegate void BetterRunWorkerCompletedEventHandler(object sender, BetterRunWorkerCompletedEventArgs args);
	public delegate void BetterAllWorkersCompletedEventHandler(object sender, EventArgs args);

	#region BetterDoWorkEventArgs
	public abstract class BetterDoWorkEventArgs : DoWorkEventArgs
	{
		public BetterDoWorkEventArgs(int id, object argument)
			: base(argument)
		{
			this.Id = id;
		}

		public bool Cancelled { get; private set; }

		public int Id { get; private set; }
		public object Tag { get; set; }
		public event BetterDoWorkEventHandler CancelRequested;
		public void SetCancelled()
		{
			this.Cancelled = true;
		}

		protected void OnCancelRequested(object sender)
		{
			if (CancelRequested != null)
				CancelRequested(sender, this);
		}
	} 
	#endregion
	#region BetterRunWorkerCompletedEventArgs
	public class BetterRunWorkerCompletedEventArgs : RunWorkerCompletedEventArgs
	{
		public BetterRunWorkerCompletedEventArgs(int id, object result, Exception error, bool cancelRequested, bool cancelled, object tag)
			: base(result, error, cancelled)
		{
			this.Id = id;
			this.CancelRequested = cancelRequested;
			this.Tag = tag;
		}

		public bool CancelRequested { get; private set; }
		public int Id { get; private set; }
		public object Tag { get; set; }
	}
	#endregion

	#region EBetterBackgroundWorkerMode
	public enum EBetterBackgroundWorkerMode
	{
		/// <summary>
		/// Processa novas requisições de RunWorkerAsync independentemente e imediatamente, sem cancelar as requisições em andamento.
		/// </summary>
		IndependentWorkers = 0,

		/// <summary>
		/// Processa novas requisições de RunWorkerAsync imediatamente, mas cancela assincronamente as requisições em andamento.
		/// </summary>
		NewWorkerCancelsPreviousWorker = 1,

		/// <summary>
		/// Espera a requisição em andamento ser concluída e processa apenas a última requisição solicitada, ignorando as requisições que acontecerem entre uma requisição em andamento e a última requisição.
		/// </summary>
		ProcessLastRequestedWorkerWhenAvailable = 2,

		/// <summary>
		/// Espera a requisição em andamento ser concluída e ignora completamente novas tentativas de requisição enquanto a corrente estiver em andamento
		/// </summary>
		IgnoreSubsequentRequests = 3,

		/// <summary>
		/// Enfileira as requisições e vai executando-as em ordem de chegada, sequencialmente.
		/// </summary>
		ProcessRequestsSequentially = 4
	} 
	#endregion

	public class BetterBackgroundWorker : Component
	{
		#region InnerBetterDoWorkEventArgs
		private class InnerBetterDoWorkEventArgs : BetterDoWorkEventArgs
		{
			public InnerBetterDoWorkEventArgs(BetterBackgroundWorker owner, int id, object argument)
				: base(id, argument)
			{
				_Owner = owner;
				_Owner.CancelOperationRequested += new Action<int>(_Owner_CancelOperationRequested);
			}

			public Exception Error { get; set; }
			public bool DoWorkCompleted { get; private set; }

			void _Owner_CancelOperationRequested(int currentId)
			{
				if (Id < currentId && !DoWorkCompleted)
					SetCancelRequested();
			}

			private BetterBackgroundWorker _Owner;

			void SetCancelRequested()
			{
				this.Cancel = true;
				OnCancelRequested(_Owner);
			}

			public void SetDoWorkCompleted()
			{
				DoWorkCompleted = true;
				_Owner.CancelOperationRequested -= new Action<int>(_Owner_CancelOperationRequested);
			}
		} 
		#endregion

		#region Constructor
		public BetterBackgroundWorker()
			: base()
		{
		} 
		#endregion

		#region Attributes
		private EBetterBackgroundWorkerMode _Mode = EBetterBackgroundWorkerMode.IndependentWorkers;
		private List<BackgroundWorker> _BgWorkers = new List<BackgroundWorker>(2);
		private int _CurrentId = 0;
		private uint _MilliSecondsToWaitBeforeDoWork = 0;

		private object _QueuedRequestsLockObject = new object();
		private Queue<InnerBetterDoWorkEventArgs> _QueuedRequests = new Queue<InnerBetterDoWorkEventArgs>();
		#endregion

		#region Properties
		public EBetterBackgroundWorkerMode Mode
		{
			get { return _Mode; }
			set
			{
				if (_BgWorkers.Count > 0)
					throw new InvalidOperationException("O modo de operação do BetterBackgroundWorker deve ser setado antes do início das execuções.");

				_Mode = value;
			}
		}
		public bool IsBusy
		{
			get 
			{
				if (_BgWorkers.Count == 1)
					return _BgWorkers[0].IsBusy;
				else
					return _BgWorkers.Count > 0; 
			}
		}
		public uint MilliSecondsToWaitBeforeDoWork
		{
			get { return _MilliSecondsToWaitBeforeDoWork; }
			set { _MilliSecondsToWaitBeforeDoWork = value; }
		}
		#endregion

		#region Public Methods
		public bool RunWorkerAsync()
		{
			return 
				RunWorkerAsync(null);
		}
		public void CancelAsync()
		{
			_CancelPreviousOperations(_CurrentId + 1);
		}
		public bool RunWorkerAsync(object argument)
		{
			bool runSucceded = false;
			int newId = _GetNewId();
			InnerBetterDoWorkEventArgs args = new InnerBetterDoWorkEventArgs(this, newId, argument);

			switch (_Mode)
			{
				case EBetterBackgroundWorkerMode.IndependentWorkers:
				case EBetterBackgroundWorkerMode.NewWorkerCancelsPreviousWorker:
					_RunAvailableBgWorkerAsync(args);
					runSucceded = true;
					break;
				case EBetterBackgroundWorkerMode.IgnoreSubsequentRequests:
					bool busy = false;
					lock (_BgWorkers)
						busy = _BgWorkers.Exists(bgw => bgw.IsBusy);
					if (!busy)
					{
						_RunAvailableBgWorkerAsync(args);
						runSucceded = true;
					}
					break;
				case EBetterBackgroundWorkerMode.ProcessRequestsSequentially:
				case EBetterBackgroundWorkerMode.ProcessLastRequestedWorkerWhenAvailable:

					lock (_QueuedRequestsLockObject)
						_QueuedRequests.Enqueue(args);

					_TryRunAvailableBgWorkerAsync();
					runSucceded = true;
					break;

			}

			return runSucceded;
		}

		#endregion

		#region BgWorker Event Handlers
		void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			InnerBetterDoWorkEventArgs args = (InnerBetterDoWorkEventArgs)e.Argument;

			try
			{
				if (MilliSecondsToWaitBeforeDoWork != 0)
					System.Threading.Thread.Sleep((int)MilliSecondsToWaitBeforeDoWork);

				if (!args.Cancel && !args.Cancelled)
					_OnDoWork(args);
			}
			catch (Exception ex)
			{
				args.Error = ex;
			}
			finally
			{
				e.Result = args;
			}
		}
		void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			InnerBetterDoWorkEventArgs doWorkArgs = (InnerBetterDoWorkEventArgs)e.Result;

			doWorkArgs.SetDoWorkCompleted();

			_BgWorkers.Remove(sender as BackgroundWorker);

			BetterRunWorkerCompletedEventArgs completedArgs = new BetterRunWorkerCompletedEventArgs(doWorkArgs.Id, doWorkArgs.Result, doWorkArgs.Error, doWorkArgs.Cancel, doWorkArgs.Cancelled, doWorkArgs.Tag);

			_OnRunWorkerCompleted(completedArgs);

			if (_Mode == EBetterBackgroundWorkerMode.ProcessRequestsSequentially)
				_TryRunAvailableBgWorkerAsync();

			if (!IsBusy)
			{
				_OnAllWorkersCompleted(new EventArgs());
			}
		}
		#endregion

		#region Public Events
		public event BetterDoWorkEventHandler DoWork;
		public event BetterRunWorkerCompletedEventHandler RunWorkerCompleted;
		public event BetterAllWorkersCompletedEventHandler AllWorkersCompleted;

		/// <summary>
		/// Evento disparado imediatamente antes de começar o DoWork, ainda na Thread principal.
		/// </summary>
		public event BetterDoWorkEventHandler DoWorkStarting;

		private event Action<int> CancelOperationRequested;

		private void _OnDoWork(BetterDoWorkEventArgs args)
		{
			if (DoWork != null)
				DoWork(this, args);
		}
		private void _OnDoWorkStarting(InnerBetterDoWorkEventArgs args)
		{
			if (DoWorkStarting != null)
				DoWorkStarting(this, args);
		}
		private void _OnRunWorkerCompleted(BetterRunWorkerCompletedEventArgs args)
		{
			if (RunWorkerCompleted != null)
				RunWorkerCompleted(this, args);
		}

		private void _OnAllWorkersCompleted(EventArgs args)
		{
			if (AllWorkersCompleted != null)
				AllWorkersCompleted(this, args);
		}

		#endregion

		#region Private Methods
		private int _GetNewId()
		{
			int newId = ++_CurrentId;

			if (_Mode == EBetterBackgroundWorkerMode.NewWorkerCancelsPreviousWorker)
			{
				_CancelPreviousOperations(newId);
			}

			return newId;
		}
		private void _CancelPreviousOperations(int currentId)
		{
			if (CancelOperationRequested != null)
				CancelOperationRequested(currentId);
		}

		private void _RunAvailableBgWorkerAsync(InnerBetterDoWorkEventArgs args)
		{
			BackgroundWorker availableBgWorker = null;
			lock (_BgWorkers)
				availableBgWorker = _BgWorkers.Find(bgw => !bgw.IsBusy);

			if (availableBgWorker == null)
			{
				availableBgWorker = new BackgroundWorker();
				availableBgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
				availableBgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

				_BgWorkers.Add(availableBgWorker);
			}

			_OnDoWorkStarting(args);
			availableBgWorker.RunWorkerAsync(args);
		}

		private void _TryRunAvailableBgWorkerAsync()
		{
			lock(_QueuedRequestsLockObject)
			{
				// Mantém apenas a última requisição na fila
				if(_Mode == EBetterBackgroundWorkerMode.ProcessLastRequestedWorkerWhenAvailable)
				{
					while(_QueuedRequests.Count > 1)
					{
						_QueuedRequests.Dequeue();
					}
				}
				if (_QueuedRequests.Count > 0 && _BgWorkers.Count == 0)
				{
					InnerBetterDoWorkEventArgs args = _QueuedRequests.Dequeue();
					_RunAvailableBgWorkerAsync(args);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
		#endregion
	}
}
