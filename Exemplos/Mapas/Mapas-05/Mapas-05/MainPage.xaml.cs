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


namespace Mapas_05
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

        private void CarregaMeuMapa(object sender, RoutedEventArgs e)
        {
            ApresentaMapa();
        }

        private void ApresentaMapa()
        {
            var GeoSaoPaulo = new Geopoint(new BasicGeoposition() { Latitude = -23.550483, Longitude = -46.633106 });
            MapaSaoPaulo.TrySetViewAsync(GeoSaoPaulo, 11.4086892086054, 0, 0, MapAnimationKind.Bow);
        }

        private void ReferenciaChecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.TrySetViewAsync(MapaSaoPaulo.Center, MapaSaoPaulo.ZoomLevel, 340, 35, MapAnimationKind.Bow);
            MapaSaoPaulo.LandmarksVisible = true;
        }

        private void ReferenciaUnchecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.LandmarksVisible = false;
            MapaSaoPaulo.TrySetViewAsync(MapaSaoPaulo.Center, MapaSaoPaulo.ZoomLevel, 0, 0, MapAnimationKind.Bow);
        }

        private void PedestreChecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.PedestrianFeaturesVisible = true;
        }

        private void PedestreUnchecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.PedestrianFeaturesVisible = false;
        }

        private void DarkChecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.ColorScheme = MapColorScheme.Dark;
        }

        private void DarkUnchecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.ColorScheme = MapColorScheme.Light;
        }

        private void TrafegoChecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.TrafficFlowVisible = true;
        }

        private void TrafegoUnchecked(object sender, RoutedEventArgs e)
        {
            MapaSaoPaulo.TrafficFlowVisible = false;
        }
        
    }
}
