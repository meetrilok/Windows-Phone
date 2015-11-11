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
// Inserção Obrigatória
// ====================================================================

using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Animacao_02
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

        private void animateButton_Click(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage(new Uri("ms-appx:///Assets/sunny.png"));
            animatedImage.Source = image;
        }

        private void animatedImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;

            if (img == null)
                return;

            Storyboard s = new Storyboard();

            DoubleAnimation doubleAni = new DoubleAnimation();
            doubleAni.To = 1;
            doubleAni.Duration = new Duration(TimeSpan.FromMilliseconds(2000));

            Storyboard.SetTarget(doubleAni, img);
            Storyboard.SetTargetProperty(doubleAni, "Opacity");

            s.Children.Add(doubleAni);
            s.Begin();
        }
    }
}
