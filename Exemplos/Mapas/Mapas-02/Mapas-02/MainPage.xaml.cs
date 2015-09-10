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

using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Shapes;

namespace Mapas_02
{
    public sealed partial class MainPage : Page
    {
        double dLatitude = 0;
        double dLongetude = 0;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            PegaLocal();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void PegaLocal ()
        {

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                dLatitude = geoposition.Coordinate.Latitude;
                dLongetude = geoposition.Coordinate.Longitude;
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    dLatitude = 0;
                    dLongetude = 0;
                }
                //else
                {
                    // something else happened acquring the location
                }
            }
        }


        private void CarregandoMapa(object sender, RoutedEventArgs e)
        {
            ZoomCristo();
        }

        private void ZoomCristo()
        {
            var CristoRedentor = new Geopoint(new BasicGeoposition() { Latitude = dLatitude, Longitude = dLongetude });
            MeuMapa.TrySetViewAsync(CristoRedentor, 15D, 0, 0, MapAnimationKind.Bow);
        }

    }
}
