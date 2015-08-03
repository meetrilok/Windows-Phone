using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace TextBox_01
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
            lblResultado.Text = "Voce Digitou "+txtDigita.Text;
        }

        private void AvaliaSenha(object sender, TextChangedEventArgs e)
        {
            if ( txtDigita.Text.Length < 3 )
            {
                lblResultado.Text = "Senha Fraca";
            }
            else
            {
                if ( txtDigita.Text.Length > 3 && txtDigita.Text.Length < 5)
                {
                    lblResultado.Text = "Senha Forte";
                }
                else
                {
                    if (txtDigita.Text.Length > 5)
                    {
                        lblResultado.Text = "Senha Muito Forte";
                    }
                }
            }
        }

    }
}
