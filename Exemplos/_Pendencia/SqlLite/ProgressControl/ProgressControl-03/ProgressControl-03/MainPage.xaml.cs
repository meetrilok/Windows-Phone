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

namespace ProgressControl_03
{   
    public sealed partial class MainPage : Page
    {
        double dProgresso = 0;    
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AdicionaBarra(object sender, RoutedEventArgs e)
        {
            dProgresso = MinhaBarra.Value;
            dProgresso += 5;
            MinhaBarra.Value = dProgresso;
        }

        private void SubtraiBarra(object sender, RoutedEventArgs e)
        {
            dProgresso -= 5;
            MinhaBarra.Value = dProgresso;
        }

        private void ResetaBarra(object sender, RoutedEventArgs e)
        {
            dProgresso = 0;
            MinhaBarra.Value = dProgresso;
        }
    }
}
