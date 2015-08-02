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

using Windows.UI.ViewManagement;

namespace Config_02
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

        private async void ShowStatusBar(object sender, RoutedEventArgs e)
        {
            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.ShowAsync();
        }

        private async void HideStatusBar(object sender, RoutedEventArgs e)
        {
            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.HideAsync();
        }

        private async void ShowProgressIndicator(object sender, RoutedEventArgs e)
        {
            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.ShowAsync();
            await statusBar.ProgressIndicator.ShowAsync();
        }

        private async void HideProgressIndicator(object sender, RoutedEventArgs e)
        {
            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.ProgressIndicator.HideAsync();
        }
    }
}
