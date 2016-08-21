using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using BusDataCollector.Components;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Threading;
using HackerCidadao4.Services;
using HackerCidadao4.Entities;
using HackerCidadao4.Data;

namespace HackerCidadao4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ULTRASSSOM_FILTER = "Ultrassom";

        private BetterBackgroundWorker bwLoadVehicles;
        private string _currentJsonData;
        private List<SecoSensor> _secoSensors;
        private List<Sensor> _sensors;
        List<Manhole> _repository;
        private DispatcherTimer _dispatcherTimer;
        private int _selectedManholeId;

        public MainWindow()
        {
            InitializeComponent();

            bwLoadVehicles = new BetterBackgroundWorker();
            bwLoadVehicles.Mode = EBetterBackgroundWorkerMode.ProcessLastRequestedWorkerWhenAvailable;
            bwLoadVehicles.DoWork += BwLoadVehicles_DoWork;
            bwLoadVehicles.RunWorkerCompleted += BwLoadVehicles_RunWorkerCompleted;

            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            _dispatcherTimer.Start();

            FillSidebar();

            bwLoadVehicles.RunWorkerAsync();
        }

        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            bwLoadVehicles.RunWorkerAsync();
        }

        private void BwLoadVehicles_DoWork(object sender, BetterDoWorkEventArgs args)
        {
            _currentJsonData = Network.SecoData();
            _secoSensors = _ParseSecoSensors(_currentJsonData);
            try
            {
                _currentJsonData = Network.SensorsData();
                _sensors = _ParseSensors(_currentJsonData).Sensor;
            }catch
            {

            }
        }

        private void BwLoadVehicles_RunWorkerCompleted(object sender, BetterRunWorkerCompletedEventArgs args)
        {
            _RefreshMap();
        }

        private void _RefreshMap()
        {
            if (_secoSensors == null)
                return;

            MapControl.Children.Clear();

            bool gasAlert = GasAlertCheckbox.IsChecked.Value;
            bool volumeAlert = VolumeAlertCheckbox.IsChecked.Value;
            _repository = _secoSensors?.Select(m => m.CreateManhole()).ToList();
            ManholeRepository.Instance.InsertSensorsValues(_sensors);
            _repository.AddRange(ManholeRepository.Instance.GetManholes(volumeAlert, gasAlert).Where(m => m.Id % 5 == 0));


            foreach (Manhole m in _repository)
            {
                Pushpin pin = new Pushpin();

                //ControlTemplate template = (ControlTemplate)this.FindResource("CutomPushpinTemplate");
                //pin.Template = template;

                pin.Width = 50;
                pin.Height = 50;
                pin.PositionOrigin = PositionOrigin.BottomLeft;
                pin.Location = new Location(m.Latitude, m.Longitude);
                pin.Tag = m.Id;
                pin.MouseDown += Pin_MouseDown;
                if (m.GasState == EImportanceState.Critical || m.VolumeState == EImportanceState.Critical)
                    pin.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(127, 0, 0));
                else if (m.VolumeState == EImportanceState.Alert || m.GasState == EImportanceState.Alert)
                    pin.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(229, 148, 0));
                else
                    pin.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 127, 0));

                MapControl.Children.Add(pin);
            }

            FillSidebar();
        }

        private void Pin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InfoPanel.Visibility = Visibility.Visible;
            _selectedManholeId = (int)(sender as Pushpin).Tag;
            FillSidebar();
        }

        private List<SecoSensor> _ParseSecoSensors(string json)
        {
            return JsonConvert.DeserializeObject<List<SecoSensor>>(json);
        }

        private SensorList _ParseSensors(string json)
        {
            return JsonConvert.DeserializeObject<SensorList>(json);
        }

        private MultiSensor _ParseMultiSensor(string json)
        {
            return JsonConvert.DeserializeObject<MultiSensor>(json);
        }

        private string _SerializeManholes(List<Manhole> manholes)
        {
            return JsonConvert.SerializeObject(manholes);
        }

        private void FillSidebar()
        {
            Manhole manhole = null;

            manhole = _repository?.Find(m => m.Id == _selectedManholeId);
            
            if (manhole != null)
            {
                TextName.Text = manhole.Name;
                TextAddress.Text = manhole.Street;
                TextCurrentVolume.Text = manhole.FillRatio * 100 + " %";
                TextCurrentHeight.Text = string.Format("{0:0.00} cm", manhole.CurrentHeight);
                TextDimensions.Text = manhole.Dimensions.ToString();

                var date = manhole.LastManteinance.Date;
                TextManteinance.Text = string.Format("{0:00}/{1:00}/{2:00}", date.Day, date.Month, date.Year);

                date = manhole.LastUpdated.Date;
                var time = manhole.LastUpdated.TimeOfDay;
                TextUpdated.Text = string.Format("{0:00}/{1:00}/{2:00}", date.Day, date.Month, date.Year);
                TextUpdatedTime.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

                switch (manhole.GasState)
                {
                    case EImportanceState.Normal:
                        TextStatus.Text = "Normal";
                        break;
                    case EImportanceState.Alert:
                        TextStatus.Text = "Em alerta";
                        break;
                    case EImportanceState.Critical:
                        TextStatus.Text = "Estado Crítico";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                InfoPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (AllCheckbox.IsChecked.Value && (sender == AllCheckbox))
            {
                GasAlertCheckbox.IsChecked = false;
                VolumeAlertCheckbox.IsChecked = false;
            }
            else if (GasAlertCheckbox.IsChecked.Value || VolumeAlertCheckbox.IsChecked.Value)
            {
                AllCheckbox.IsChecked = false;
            }
            else
            {
                AllCheckbox.IsChecked = true;
            }

            _RefreshMap();
        }

    }
}
