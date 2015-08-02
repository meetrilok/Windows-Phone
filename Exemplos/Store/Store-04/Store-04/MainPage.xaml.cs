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

namespace Store_04
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

        private void btnGravaCidade_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("Grupo1", Windows.Storage.ApplicationDataCreateDisposition.Always);

            localSettings.Containers["Grupo1"].Values["Cidade"] = "Porto Alegre";
            txtMensagem.Text = "Cidade Gravada com Sucesso";
        }

        private void btnLeituraCidade_Click(object sender, RoutedEventArgs e)
        {

            if ( localSettings.Containers.ContainsKey("Grupo1") )
            {
                if ( localSettings.Containers["Grupo1"].Values.ContainsKey("Cidade") )
                {
                    Object objCidade = localSettings.Containers["Grupo1"].Values["Cidade"];
                    txtResultadoCidade.Text = objCidade.ToString();
                    txtMensagem.Text = "Cidade Lida com Sucesso";
                }
            }

        }

        private void btnGravaPais_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("Grupo2", Windows.Storage.ApplicationDataCreateDisposition.Always);

            localSettings.Containers["Grupo2"].Values["Pais"] = "Brasil";
            txtMensagem.Text = "Pais Gravado com Sucesso";
        }

        private void btnLeituraPais_Click(object sender, RoutedEventArgs e)
        {

            if (localSettings.Containers.ContainsKey("Grupo2"))
            {
                if (localSettings.Containers["Grupo2"].Values.ContainsKey("Pais"))
                {
                    Object objCidade = localSettings.Containers["Grupo2"].Values["Pais"];
                    txtResultadoCidade.Text = objCidade.ToString();
                    txtMensagem.Text = "Pais Lido com Sucesso";
                }
            }

        }

        private void btnLimpa_Click(object sender, RoutedEventArgs e)
        {
            txtMensagem.Text = "Sem Mensagens";
            txtResultadoCidade.Text = "Sem Resultados";
            txtResultadoPais.Text = "Sem Resultados";
        }

    }
}
