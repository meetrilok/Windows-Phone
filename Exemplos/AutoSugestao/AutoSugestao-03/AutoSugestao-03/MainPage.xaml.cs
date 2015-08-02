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

namespace AutoSugestao_03
{
    public sealed partial class MainPage : Page
    {        
        List<string> ListaSugestoes = new List<string>() { "S1", "S2", "S3", "U1", "U2", "U3" };

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void FocoSugestao(object sender, RoutedEventArgs e)
        {
            CaixaTexto.ItemsSource = ListaSugestoes;
        }

        private void AlteracaoTexto(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            string strFiltro = sender.Text.ToUpper();
            CaixaTexto.ItemsSource = ListaSugestoes.Where(s => s.ToUpper().Contains(strFiltro));
        }
    }
}
