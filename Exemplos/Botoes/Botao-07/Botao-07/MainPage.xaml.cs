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

namespace Botao_07
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Casa_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Botão Casa Escolhido";
        }

        private void Letra_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Botão Letra Escolhido";
        }

        private void Lixo_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Botão Lixo Escolhido";
        }
    }
}
