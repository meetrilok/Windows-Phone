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

// Referencia
// http://www.silverlightshow.net/items/Windows-8.1-Exploring-new-controls-Hub-CommandBar-Flyouts-and-Pickers.aspx
// http://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn308516.aspx
//

namespace FlyOut_01
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

        private void OpcaoClick(object sender, RoutedEventArgs e)
        {
            if (Opcao2.IsChecked == true)
            {
                lblResultado.Text = "Opção #2 Definida";
                Opcao2.IsEnabled = false;
            }

            if ( Opcao3.IsChecked == true )
            {
                lblResultado.Text = "Opção #3 Definida";
                Opcao3.IsEnabled = false;
            }
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Opções Resetadas";
            Opcao2.IsEnabled = true;
            Opcao3.IsEnabled = true;
        }
    }
}
