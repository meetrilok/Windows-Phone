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

using System.Net.Http;

namespace HttpClient_01
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var Resposta  = await httpClient.GetAsync(new Uri("http://192.168.25.80/", UriKind.RelativeOrAbsolute));

            if ( Resposta.IsSuccessStatusCode )
            {
                Resposta.EnsureSuccessStatusCode();
                var Conteudo = Resposta.Content.ReadAsStringAsync();
                lblResultado.Text = Conteudo.Result.ToString();
            }
            else
            {
                lblResultado.Text = "Servidor Não Disponível";
            }

        }
    }
}