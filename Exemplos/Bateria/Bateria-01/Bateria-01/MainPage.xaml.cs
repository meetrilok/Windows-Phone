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
// Inclusao Obrigatoria
// ====================================================================

using Windows.Phone.Devices.Power;

namespace Bateria_01
{
    public sealed partial class MainPage : Page
    {
        private readonly Battery _battery;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            var Percentual = PercentualBateria();
            lblResultado.Text = Percentual + "%";
        }

        public string PercentualBateria()
        {
            return Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercent.ToString();
        }
    }
}
