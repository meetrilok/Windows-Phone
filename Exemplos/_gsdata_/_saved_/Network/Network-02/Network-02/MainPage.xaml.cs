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
using Microsoft.Phone.Net.NetworkInformation;

namespace Network_02
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

        private void ChecaDisponibilidade(object sender, RoutedEventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("Network available:  ");
            sb.AppendLine(DeviceNetworkInformation.IsNetworkAvailable.ToString());

            sb.Append("Cellular enabled:  ");
            sb.AppendLine(DeviceNetworkInformation.IsCellularDataEnabled.ToString());

            sb.Append("Roaming enabled:  ");
            sb.AppendLine(DeviceNetworkInformation.IsCellularDataRoamingEnabled.ToString());

            sb.Append("Wi-Fi enabled:  ");
            sb.AppendLine(DeviceNetworkInformation.IsWiFiEnabled.ToString());

            lblResultado.Text = sb.ToString();
        }
    }
}
