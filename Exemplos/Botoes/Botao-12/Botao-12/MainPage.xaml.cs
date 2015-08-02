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

using Windows.UI.Xaml;

namespace Botao_12
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            MeuLayout();
        }

        private void MeuLayout ()
        {
            btnExecuta.Width = 100;
            btnExecuta.Height = 50;
            btnExecuta.Content = "Executa";
            btnExecuta.Click += btnExecuta_Click;
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Ativado Programaticamente";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
