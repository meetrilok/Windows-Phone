using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TextBox_02
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

        private void ReadWriteTB_TextChanged(object sender, RoutedEventArgs e)
        {
            ReadOnlyTB.Text = ReadWriteTB.Text;
        }

        private void WatermarkTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (WatermarkTB.Text == "Search")
            {
                WatermarkTB.Text = "";
                SolidColorBrush Brush1 = new SolidColorBrush();
                Brush1.Color = Colors.Magenta;
                WatermarkTB.Foreground = Brush1;
            }
        }

        private void WatermarkTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (WatermarkTB.Text == String.Empty)
            {
                WatermarkTB.Text = "Search";
                SolidColorBrush Brush2 = new SolidColorBrush();
                Brush2.Color = Colors.Blue;
                WatermarkTB.Foreground = Brush2;
            }
        }
    }
}
