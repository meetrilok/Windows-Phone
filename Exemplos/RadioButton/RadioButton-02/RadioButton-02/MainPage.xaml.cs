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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace RadioButton_02
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

        private void Click_BtnOK(object sender, RoutedEventArgs e)
        {
            String strResultado = "";

            if (rdbOpcao1.IsChecked == true)
            {
                strResultado = "Primeiro Radio Apertado";
            }
                

            if (rdbOpcao2.IsChecked == true)
            {
                strResultado = strResultado + "\nSegundo Radio Apertado";
            }
                

            if ( rdbOpcao3.IsChecked == true)
            {
                strResultado = strResultado + "\nTerceiro Radio Apertado";
            }
                
            if (rdbOpcao4.IsChecked == true)
            {
                strResultado = strResultado + "\nQuarto Radio Apertado";
            }

            TxtResultado.Text = strResultado;
        }
    }
}
