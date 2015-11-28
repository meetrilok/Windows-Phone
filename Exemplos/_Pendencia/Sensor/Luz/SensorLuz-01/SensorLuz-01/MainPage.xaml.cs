using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SensorLuz_01
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void sensor_ReadingChanged(LightSensor sender, LightSensorReadingChangedEventArgs args)
        {
            Debug.WriteLine("Sensor working");
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            lblResultado.Text = "Lux: " + args.Reading.IlluminanceInLux.ToString()
            );
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            LightSensor sensor;
            sensor = LightSensor.GetDefault();
            sensor.ReportInterval = 500;
            sensor.ReadingChanged += sensor_ReadingChanged;
        }
    }
}
