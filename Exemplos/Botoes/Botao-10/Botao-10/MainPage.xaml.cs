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

using System;
using System.Diagnostics;

namespace Botao_10
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
            Button btnBotao = sender as Button;
            switch (btnBotao.Name )
            {
                case    "Botao1":
                        Debug.WriteLine("Botao #1 Pressionado");
                        break;

                case    "Botao2":
                        Debug.WriteLine("Botao #2 Pressionado");
                        break;

                case    "Botao3":
                        Debug.WriteLine("Botao #3 Pressionado");
                        break;

                case    "Botao4":
                        Debug.WriteLine("Botao #4 Pressionado");
                        break;

                case    "Botao5":
                        Debug.WriteLine("Botao #5 Pressionado");
                        break;

                case    "Botao6":
                        Debug.WriteLine("Botao #6 Pressionado");
                        break;

                case    "Botao7":
                        Debug.WriteLine("Botao #7 Pressionado");
                        break;

                case    "Botao8":
                        Debug.WriteLine("Botao #8 Pressionado");
                        break;

                case    "Botao9":
                        Debug.WriteLine("Botao #9 Pressionado");
                        break;

                default:
                    break;
            }
        }
    }
}
