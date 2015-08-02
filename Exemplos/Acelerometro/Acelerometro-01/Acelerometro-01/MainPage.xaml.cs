using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// ====================================================================
// Insercao Obrigatoria
// ====================================================================

using Windows.Devices.Sensors;      
using Windows.UI.Popups;            
using Windows.UI.Core;          

namespace Acelerometro_01
{
    public sealed partial class MainPage : Page
    {
        public Accelerometer accelerometer { get; set; }
        private uint desiredReportInterval { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            accelerometer = Accelerometer.GetDefault();
            if (accelerometer != null)
            {
                uint minReportInterval = accelerometer.MinimumReportInterval;
                desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;
                accelerometer.ReportInterval = desiredReportInterval;
                accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Nenhum Acelerometro foi Encontrado");
                msgDialog.ShowAsync();
            }

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = args.Reading;
                lblPosX.Text = "X = " + String.Format("{0,5:0.00}", reading.AccelerationX);
                lblPosY.Text = "Y = " + String.Format("{0,5:0.00}", reading.AccelerationY);
                lblPosZ.Text = "Z = " + String.Format("{0,5:0.00}", reading.AccelerationZ);
            });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
