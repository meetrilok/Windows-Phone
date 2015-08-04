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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace AppBar_04
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

        private void AdicionaOpcaoAppBar(object sender, RoutedEventArgs e)
        {
            bottomAppBar.PrimaryCommands.Insert(0, new AppBarSeparator());

            AppBarButton addButton = new AppBarButton();
            addButton.Icon = new SymbolIcon(Symbol.Add);
            addButton.Label = "Add";
            addButton.Click += AdicionaOpcaoAppBar;
            bottomAppBar.PrimaryCommands.Insert(0, addButton);
        }

        private void RemoveOpcaoAppBar(object sender, RoutedEventArgs e)
        {

            CommandBar bottomCommandBar = this.BottomAppBar as CommandBar;
            if (bottomCommandBar != null)
            {
                AppBarButton b = bottomCommandBar.PrimaryCommands[0] as AppBarButton;
                b.Click -= RemoveOpcaoAppBar;

                // Remove AppBarButton.
                bottomCommandBar.PrimaryCommands.RemoveAt(0);

                // Remove AppBarSeparator.
                bottomCommandBar.PrimaryCommands.RemoveAt(0);
            }


        }
    }
}
