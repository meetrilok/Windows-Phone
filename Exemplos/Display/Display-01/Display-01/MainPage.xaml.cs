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
using Windows.Graphics.Display; // Inserir

namespace Display_01
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
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            double dResX = Window.Current.Bounds.Width * scaleFactor;
            double dResY = Window.Current.Bounds.Height * scaleFactor;
            int iResX = Convert.ToInt32(dResX);
            int iResY = Convert.ToInt32(dResY);
            String sResX = iResX.ToString();
            String sResY = iResY.ToString();

            var width = Window.Current.Bounds.Width * (int)DisplayProperties.ResolutionScale / 100;
            var height = Window.Current.Bounds.Height * (int)DisplayProperties.ResolutionScale / 100;
            var dpi = DisplayInformation.GetForCurrentView().RawDpiY;
            var screenDiagonal = Math.Sqrt(Math.Pow(width / dpi, 2) + Math.Pow(height / dpi, 2));

            lblResultado.Text = "Resolução " + sResX + " x " + sResY + "\n"+
                                "Diagonal = "+ screenDiagonal.ToString();
        }
    }
}