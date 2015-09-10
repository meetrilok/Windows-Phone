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

namespace Mapas_03
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

        private async void ApresentaMapa()
        {
            var GeoSaoPaulo = new Geopoint(new BasicGeoposition() { Latitude = -23.550483, Longitude = -46.633106 });          
            var MeuPin = CriaMeuPin();
            MapaSaoPaulo.Children.Add(MeuPin);

            MapControl.SetLocation(MeuPin, GeoSaoPaulo);
            MapControl.SetNormalizedAnchorPoint(MeuPin, new Point(0.0, 1.0));

            MapaSaoPaulo.TrySetViewAsync(GeoSaoPaulo, 15, 0, 0, MapAnimationKind.Bow);
        }

        private DependencyObject CriaMeuPin()
        {
            var MeuGrid = new Grid();
            MeuGrid.RowDefinitions.Add(new RowDefinition());
            MeuGrid.RowDefinitions.Add(new RowDefinition());
            MeuGrid.Background = new SolidColorBrush(Colors.Transparent);

            var MeuRetangulo = new Rectangle { Fill = new SolidColorBrush(Colors.Red), Height = 10, Width = 22 };
            MeuRetangulo.SetValue(Grid.RowProperty, 0);
            MeuRetangulo.SetValue(Grid.ColumnProperty, 0);
            MeuGrid.Children.Add(MeuRetangulo);

            var MeuPoligono = new Polygon()
            {
                Points = new PointCollection() { new Point(1, 0), new Point(22, 0), new Point(11, 40) },
                Stroke = new SolidColorBrush(Colors.Red),
                Fill = new SolidColorBrush(Colors.Red)
            };
            MeuPoligono.SetValue(Grid.RowProperty, 1);
            MeuPoligono.SetValue(Grid.ColumnProperty, 0);
            MeuGrid.Children.Add(MeuPoligono);

            return MeuGrid;
        }


    }
}
