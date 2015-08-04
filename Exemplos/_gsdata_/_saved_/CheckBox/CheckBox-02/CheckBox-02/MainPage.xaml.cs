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

namespace CheckBox_02
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            chkOpcao1A.IsChecked = true;
            chkOpcao1B.IsChecked = true;
        }

        private void chkOpcao1_Checked(object sender, RoutedEventArgs e)
        {
            if ( chkOpcao1.IsChecked == true )
            {
                if (chkOpcao1A.IsChecked == true) chkOpcao1A.IsChecked = false;
                if (chkOpcao1B.IsChecked == true) chkOpcao1B.IsChecked = false;

                chkOpcao1A.IsEnabled = false;
                chkOpcao1B.IsEnabled = false;
            }
            else
            {
                chkOpcao1A.IsEnabled = true;
                chkOpcao1B.IsEnabled = true;
            }
        }

        private void ClickLimpa(object sender, RoutedEventArgs e)
        {
            chkOpcao1.IsChecked  = false;
            chkOpcao1A.IsChecked = false;
            chkOpcao1B.IsChecked = false;
        }

        private void ClickMarca(object sender, RoutedEventArgs e)
        {
            chkOpcao1.IsChecked = true;
            chkOpcao1A.IsChecked = true;
            chkOpcao1B.IsChecked = true;
        }
   }
}
