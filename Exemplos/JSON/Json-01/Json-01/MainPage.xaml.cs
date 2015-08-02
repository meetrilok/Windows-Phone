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

using Windows.Data.Json;

namespace Json_01
{
    public sealed partial class MainPage : Page
    {
        JsonValue jsonValue = JsonValue.Parse ( "{\"Largura\": 800, \"Altura\": 600, \"Titulo\": \"Meu Titulo\"}");

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            String strResultado;

            double dLargura  = jsonValue.GetObject().GetNamedNumber("Largura");
            double dAltura   = jsonValue.GetObject().GetNamedNumber("Altura");
            string strTitulo = jsonValue.GetObject().GetNamedString("Titulo");

            strResultado = "Resultados \n\n" +
                           "Largura\t= " + dLargura.ToString() + "\n" +
                           "Altura\t= " + dAltura.ToString() + "\n" +
                           "Titulo\t= " + strTitulo + "\n";

            lblResultado.Text = strResultado;

        }
    }
}
