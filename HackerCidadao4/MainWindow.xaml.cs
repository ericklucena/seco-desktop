using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using BusDataCollector.Components;
using System.Threading;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Threading;
using HackerCidadao4.Services;
using HackerCidadao4.Entities;
using Microsoft.Win32;

namespace BusDataCollector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ULTRASSSOM_FILTER = "Ultrassom";

        private BetterBackgroundWorker bwLoadVehicles;
        private string _currentJsonData;
        private List<Sensor> _sensors;
        private DispatcherTimer _dispatcherTimer;
        private Manhole _selectedManhole;

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
            _sensors = _ParseSensors(_currentJsonData);
        }

        private void BwLoadVehicles_RunWorkerCompleted(object sender, BetterRunWorkerCompletedEventArgs args)
        {
            _RefreshMap();
        }

        private void _RefreshMap()
        {
            if (_sensors == null)
                return;

            MapControl.Children.Clear();

            bool gasAlert = GasAlertCheckbox.IsChecked.Value;
            bool volumeAlert = VolumeAlertCheckbox.IsChecked.Value;
            List<Manhole> repository = _sensors?.Select(m => m.CreateManhole()).ToList();

            foreach (Manhole m in repository)
            {
                Pushpin pin = new Pushpin();

                //ControlTemplate template = (ControlTemplate)this.FindResource("CutomPushpinTemplate");
                //pin.Template = template;

                pin.Width = 50;
                pin.Height = 50;
                pin.PositionOrigin = PositionOrigin.BottomLeft;
                pin.Location = new Location(m.Latitude, m.Longitude);
                pin.Tag = m;
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
            _selectedManhole = (Manhole)(sender as Pushpin).Tag;
            FillSidebar();
        }

        private List<Sensor> _ParseSensors(string json)
        {
            return JsonConvert.DeserializeObject<List<Sensor>>(json);
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
            if (_selectedManhole != null)
            {
                TextName.Text = _selectedManhole.Name;
                TextAddress.Text = _selectedManhole.Street;
                TextCurrentVolume.Text = _selectedManhole.FillRatio * 100 + " %";
                TextDimensions.Text = _selectedManhole.Dimensions.ToString();

                var date = _selectedManhole.LastManteinance.Date.ToLocalTime();
                TextManteinance.Text = string.Format("{0:00}/{1:00}/{2:00}", date.Day, date.Month, date.Year);

                date = _selectedManhole.LastUpdated.Date.ToLocalTime();
                var time = _selectedManhole.LastUpdated.TimeOfDay;
                TextUpdated.Text = string.Format("{0:00}/{1:00}/{2:00}", date.Day, date.Month, date.Year);
                TextUpdatedTime.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

                switch (_selectedManhole.GasState)
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
