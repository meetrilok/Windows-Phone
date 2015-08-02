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

namespace Acelerometro_02
{
    public sealed partial class MainPage : Page
    {

        public Inclinometer inclinometer { get; set; }
        private uint desiredReportInterval { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            inclinometer = Inclinometer.GetDefault();
            if (inclinometer != null)
            {
                uint minReportInterval = inclinometer.MinimumReportInterval;
                desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;
                inclinometer.ReportInterval = desiredReportInterval;
                inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);
            }
            else
            {
                MessageDialog ms = new MessageDialog("Inclinometro Não Encontrado");
                ms.ShowAsync();
            }
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void ReadingChanged(object sender, InclinometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                InclinometerReading reading = args.Reading;
                lblIncX.Text = "X = " + String.Format("{0,5:0.00}", reading.RollDegrees);
                lblIncY.Text = "Y = " + String.Format("{0,5:0.00}", reading.PitchDegrees);
                lblIncZ.Text = "Z = " + String.Format("{0,5:0.00}", reading.YawDegrees);
            });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}

