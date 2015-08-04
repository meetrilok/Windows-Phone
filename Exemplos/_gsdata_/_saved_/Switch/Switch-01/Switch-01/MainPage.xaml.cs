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

namespace Switch_01
{
    
    public sealed partial class MainPage : Page
    {
        private int iToggle = 0;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (iToggle == 1)
            {                
                iToggle = 0;
                TxtResultado.Text = "OFF!!!!";
            }

            else
                iToggle = 1;
        }

        private void Click_BtnOK(object sender, RoutedEventArgs e)
        {
            switch ( iToggle )
            {
                case 0 : TxtResultado.Text = "OFF";
                         break;

                case 1 : TxtResultado.Text = "ON";
                         break;
            }
        }
    }
}
