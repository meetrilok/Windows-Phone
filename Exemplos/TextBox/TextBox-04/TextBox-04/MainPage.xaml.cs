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

namespace TextBox_04
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
            lblResultado.Text = "   Nome  = " + txtNome.Text + "\n" +
                                "   Email = " + txtEmail.Text + "\n" +
                                "Telefone = " + txtTelefone.Text + "\n" +
                                "     Web = " + txtWeb.Text;
        }
    }
}