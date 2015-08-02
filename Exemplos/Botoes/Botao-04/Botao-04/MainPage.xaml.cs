using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Roundbutton.Resources;

namespace Roundbutton
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            lblResultado.Text = txtDigita.Text;
        }
    }
}