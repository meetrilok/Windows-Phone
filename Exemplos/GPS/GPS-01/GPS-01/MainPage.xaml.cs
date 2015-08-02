using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;          // Inserir
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GPS_01
{
    public sealed partial class MainPage : Page
    {
        Geolocator geolocator = null;
        bool trackingStatus = false;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync 
                                                (
                                                    maximumAge: TimeSpan.FromMinutes(5),
                                                    timeout: TimeSpan.FromSeconds(10)
                                                );

                lblLocalizacao.Text =   "Latitude = " + 
                                        geoposition.Coordinate.Latitude.ToString("0.00") + 
                                        "\n" + 
                                        "Longetude = "+ 
                                        geoposition.Coordinate.Longitude.ToString("0.00");
            }
            catch (Exception ex)
            {
                //exception
            }
        }
    }
}

