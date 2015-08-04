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

namespace MessageDialog_01
{
    public sealed partial class MainPage : Page
    {
        // Referencias
        // http://msdn.microsoft.com/en-us/library/windows/apps/hh738363.aspx
        //
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void btnDialog1_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog dialogo = new Windows.UI.Popups.MessageDialog("Meu Texto" ); // , "Meu Título");
            await dialogo.ShowAsync();
        }
    }
}
