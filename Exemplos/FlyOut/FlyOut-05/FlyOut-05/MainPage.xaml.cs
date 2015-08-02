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

using Windows.UI;

namespace FlyOut_05
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

        private void CriaFlyOut (object sender, RoutedEventArgs e)
        {
            var flyout = new Flyout();

            var grid = new Grid();
            grid.Children.Add(new TextBlock() { 
                                                Text = "Criado Programaticamente", 
                                                Foreground = new SolidColorBrush (Colors.White), 
                                                FontSize = 20 
                                              });

            flyout.Content = grid;
            flyout.ShowAt(sender as FrameworkElement);
        }
    }
}
