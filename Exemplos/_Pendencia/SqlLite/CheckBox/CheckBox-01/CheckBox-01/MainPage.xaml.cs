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

namespace CheckBox_01
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
            String strResultado =  "";
            String strAux1 = "Opção #1 Não Checada";
            String strAux2 = "Opção #2 Não Checada";

            if ( (bool)chkOpcao1.IsChecked )
            {
                strAux1 = "Opção #1 Checada";
            }

            if ((bool)chkOpcao2.IsChecked)
            {
                strAux2 = "Opção #2 Checada";
            }

            strResultado = strAux1 + "\n" + strAux2;
            TxtResultado.Text = strResultado;
        }

        private void Click_Opcao1(object sender, RoutedEventArgs e)
        {
            TxtResultado.Text = "Opcao1";
        }
    }
}
