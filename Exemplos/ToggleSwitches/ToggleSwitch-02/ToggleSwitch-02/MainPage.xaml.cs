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

namespace ToggleSwitch_02
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

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch ToggleSwitchBase = new ToggleSwitch();
            ToggleSwitchBase.Header = "Ativado Programaticamente";
            ToggleSwitchBase.OnContent = "On";
            ToggleSwitchBase.OffContent = "Off";
            ToggleSwitchBase.Toggled += ToggleSwitch_Toggled;

            MeuStackPanel.Children.Add(ToggleSwitchBase);
        }
    }
}
