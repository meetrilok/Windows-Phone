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

using System.Xml.Linq;

namespace Xml_01
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XDocument sdcArquivo = XDocument.Load("dados.xml");

            var data = from query in sdcArquivo.Descendants("individuo")
                       select new DadosPessoas
                       {
                           Nome = (string)query.Element("nome"),
                           Sobrenome = (string)query.Element("sobrenome"),
                           Imagem = (string)query.Element("imagem")
                       };

            listBox.ItemsSource = data;

        }
    }
}