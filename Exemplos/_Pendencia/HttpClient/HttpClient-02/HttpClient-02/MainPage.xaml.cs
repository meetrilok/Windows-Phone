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
using Windows.Web.Http.Filters;


namespace HttpClient_02
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

            HttpBaseProtocolFilter Filtro = new HttpBaseProtocolFilter();
            Filtro.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
            Filtro.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;

            var httpClient = new HttpClient(Filtro);
            httpClient.BaseAddress = new Uri("http://192.168.25.80/");            
            
            //httpClient.Timeout = TimeSpan.FromMinutes(1);
            httpClient.Timeout = TimeSpan.FromSeconds(3);
            //httpClient.Timeout = TimeSpan.FromMilliseconds(200);

            try
            {
                var Resposta = httpClient.GetAsync("").Result;
                if (Resposta.IsSuccessStatusCode)
                {
                    lblResultado.Text = Resposta.Content.ReadAsStringAsync().Result.ToString();
HttpBaseProtocolFilter
                }
            }
            catch (HttpRequestException)
            {
                lblResultado.Text = "Servidor Não Disponível";
            }

            catch (TimeoutException)
            {
                lblResultado.Text = "Tempo Expirado";
            }
        }
    }
}