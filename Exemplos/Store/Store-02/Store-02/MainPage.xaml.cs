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

namespace Store_02
{
    public sealed partial class MainPage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void btnGrava_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["Cidade"] = "Porto Alegre";
            txtMensagem.Text = "Dados Gravados com Sucesso";

        }

        private void btnLimpa_Click(object sender, RoutedEventArgs e)
        {
            txtMensagem.Text = "Sem Mensagens";
            txtResultado.Text = "Sem Resultados";
        }

        private void btnLeitura_Click(object sender, RoutedEventArgs e)
        {
            Object objCidade = localSettings.Values["Cidade"];

            if (objCidade == null)
            {
                txtMensagem.Text = "Dados Não Disponíveis";
            }
            else
            {
                txtResultado.Text = objCidade.ToString();
                txtMensagem.Text = "Dados Lidos com Sucesso";
            }

        }
    }
}
