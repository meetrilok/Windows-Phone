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

namespace Mapas_04
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

        private void MostraEstrada(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.Style = MapStyle.Road;
        }

        private void MostraSatelite(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.Style = MapStyle.Aerial;
        }

        private void MostraHibrido(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.Style = MapStyle.AerialWithRoads;
        }

        private void MostraTerreno(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.Style = MapStyle.Terrain;
        }

        private void CarregaMeuMapa(object sender, RoutedEventArgs e)
        {
            ApresentaMapa();
        }

        private void ApresentaMapa()
        {
            var GeoSaoPaulo = new Geopoint(new BasicGeoposition() { Latitude = -23.550483, Longitude = -46.633106 });
            MapaSaoPaulo.TrySetViewAsync(GeoSaoPaulo, 11.4086892086054, 0, 0, MapAnimationKind.Bow);
        }

    }
}
