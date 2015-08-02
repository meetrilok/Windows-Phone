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

namespace Json_03
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

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            String strResultado;

            JsonValue jsonValue = JsonValue.Parse("[ 800, 600, \"Meu Titulo\"]");
            double dLargura = jsonValue.GetArray().GetNumberAt(0);
            double dAltura = jsonValue.GetArray().GetNumberAt(1);
            string strTitulo = jsonValue.GetArray().GetStringAt(2);

            strResultado = "Resultados \n\n" +
                           "Largura\t= " + dLargura.ToString() + "\n" +
                           "Altura\t= " + dAltura.ToString() + "\n" +
                           "Titulo\t= " + strTitulo + "\n";

            lblResultado.Text = strResultado;

        }
    }
}