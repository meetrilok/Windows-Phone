// ====================================================================
// Elimina Contadores no Emulador
// ====================================================================
#undef DEBUG 

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

namespace File_03
{
    public sealed partial class MainPage : Page
    {
        Windows.Storage.ApplicationDataContainer DadosLocal = Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder FolderLocal = Windows.Storage.ApplicationData.Current.LocalFolder;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void clkGravaDados(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataCompositeValue DadosCompostos = 
                new Windows.Storage.ApplicationDataCompositeValue();

            DadosCompostos["MeuInteiro"] = 1;
            DadosCompostos["MinhaString"] = "Hello World";

            DadosLocal.Values["DefinicaoDadosCompostos"] = DadosCompostos;
            lblResultado.Text = "Dados Locais Foram Gravados";
        }

        private void clkRecuperaDados(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataCompositeValue DadosCompostos =
                    (Windows.Storage.ApplicationDataCompositeValue)DadosLocal.Values["DefinicaoDadosCompostos"];

            if (DadosCompostos == null)
            {
                lblResultado.Text = "Dados Não Disponíveis";
            }
            else
            {
                lblResultado.Text = "Dados Recuperados" + "\n" +
                                    "String  = " + DadosCompostos["MinhaString"] + "\n" +
                                    "Inteiro = " + DadosCompostos["MeuInteiro"].ToString();
            }
        }
    }
}

