using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WIFI_01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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

        string GetLanIdentifierData(LanIdentifier lanIdentifier)
        {
            string lanIdentifierData = string.Empty;
            if (lanIdentifier == null)
            {
                return lanIdentifierData;
            }

            if (lanIdentifier.InfrastructureId != null)
            {
                lanIdentifierData += "Infrastructure Type: " + lanIdentifier.InfrastructureId.Type + "\n";
                lanIdentifierData += "Infrastructure Value: ";
                var infrastructureIdValue = lanIdentifier.InfrastructureId.Value;
                foreach (var value in infrastructureIdValue)
                {
                    lanIdentifierData += value + " ";
                }
            }

            if (lanIdentifier.PortId != null)
            {
                lanIdentifierData += "\nPort Type : " + lanIdentifier.PortId.Type + "\n";
                lanIdentifierData += "Port Value: ";
                var portIdValue = lanIdentifier.PortId.Value;
                foreach (var value in portIdValue)
                {
                    lanIdentifierData += value + " ";
                }
            }

            if (lanIdentifier.NetworkAdapterId != null)
            {
                lanIdentifierData += "\nNetwork Adapter Id : " + lanIdentifier.NetworkAdapterId + "\n";
            }
            return lanIdentifierData;
        }

        private void ChecaDisponibilidade(object sender, RoutedEventArgs e)
        {
            string lanIdentifierData = string.Empty;
            var lanIdentifiers = NetworkInformation.GetLanIdentifiers();
            if (lanIdentifiers.Count != 0)
            {
                lanIdentifierData = "Number of Lan Identifiers retrieved: " + lanIdentifiers.Count + "\n";
                for (var i = 0; i < lanIdentifiers.Count; i++)
                {
                    //Display Lan Identifier data for each identifier
                    lanIdentifierData += GetLanIdentifierData(lanIdentifiers[i]);
                    lanIdentifierData += "------------------------------------------------\n";
                }
                lblResultado.Text = lanIdentifierData;
            }
            else
            {
                lblResultado.Text = "No Lan Identifier Data found";
            }
        }
    }
}
