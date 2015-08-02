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

namespace Botao_08
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

        private void Favorito_Checado(object sender, RoutedEventArgs e)
        {
            FavoriteAppBarButton.Label = "Não é Meu Favorito";
            FavoriteAppBarButton.Icon = new SymbolIcon(Symbol.UnFavorite);
        }

        private void Favorito_NaoChecado(object sender, RoutedEventArgs e)
        {
            FavoriteAppBarButton.Label = "É Meu Favorito";
            FavoriteAppBarButton.Icon = new SymbolIcon(Symbol.Favorite);
        }
    }
}
