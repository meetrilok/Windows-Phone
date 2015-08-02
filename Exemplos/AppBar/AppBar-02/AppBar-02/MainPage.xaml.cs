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

namespace AppBar_02
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

        private void AppBarRefreshClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Opção de Refresh foi Selecionado";
        }

        private void AppBarHelpClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Opção de Help foi Selecionado";
        }

        private void AppBarRemoveClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Opção de Remoção foi Selecionado";
        }

        private void AppBarAdicaoClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Opção de Adição foi Selecionado";
        }
    }
}
