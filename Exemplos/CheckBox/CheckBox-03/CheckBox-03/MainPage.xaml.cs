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

using Windows.UI.Xaml.Controls;
using Windows.UI;

namespace CheckBox_03
{
    public sealed partial class MainPage : Page
    {
        Color clrFundo;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void chkOpcao1_Checked(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Cor de Fundo Alterada";
            SolidColorBrush clrFund = (SolidColorBrush) chkOpcao1.Background;
            chkOpcao1.Background = new SolidColorBrush(Colors.Green);
        }

        private void chkOpcao1_UnChecked(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = "Cor de Fundo Restaurada";
            chkOpcao1.Background = new SolidColorBrush(clrFundo);
        }
    }
}
