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

using System.Diagnostics;

namespace WebView_04
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            Uri url;
            String strSite = txtURL.Text;

            if (Uri.TryCreate(strSite, UriKind.RelativeOrAbsolute, out url))
            {

                NavegadorWeb.Navigate(url);
            }

        }

        private void CarregouPagina(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            Debug.WriteLine("[WebView-03] Carregamento da Página Completado com Sucesso");
        }

        private void PaginaFalhou(object sender, WebViewNavigationFailedEventArgs e)
        {
            Debug.WriteLine("[WebView-03] Falha no Carregamento da Página");
        }

        private void LoadWebView(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("[WebView-03] Load do WebView");
        }

        private void InicioPagina(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            Debug.WriteLine("[WebView-03] Iniciando o Load da Página");
        }
    }
}
