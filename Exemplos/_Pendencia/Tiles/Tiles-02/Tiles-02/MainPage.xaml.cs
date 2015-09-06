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

using NotificationsExtensions.BadgeContent;
using NotificationsExtensions.TileContent;
using System.Collections.ObjectModel;
using Windows.UI.Notifications;

namespace Tiles_02
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

        void LimpaBadge(object sender, RoutedEventArgs e)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
        }

        void AtualizaBadge()
        {
            ITileSquare310x310Text09 tileContent = TileContentFactory.CreateTileSquare310x310Text09();
            tileContent.TextHeadingWrap.Text = "Olá Estou Atualizando o Tile com um Texto";

            ITileWide310x150Text03 wide310x150Content = TileContentFactory.CreateTileWide310x150Text03();
            wide310x150Content.TextHeadingWrap.Text = "Olá Estou Atualizando o Tile com um Texto";

            ITileSquare150x150Text04 square150x150Content = TileContentFactory.CreateTileSquare150x150Text04();
            square150x150Content.TextBodyWrap.Text = "Olá Estou Atualizando o Tile com um Texto";

            wide310x150Content.Square150x150Content = square150x150Content;
            tileContent.Wide310x150Content = wide310x150Content;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

        void MostraAtualizacao(object sender, RoutedEventArgs e)
        {
            AtualizaBadge();

        }

    }
}
