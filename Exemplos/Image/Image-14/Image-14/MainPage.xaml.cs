﻿using System;
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
// Insercao Obrigatoria
// ====================================================================

using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Display;
using System.Diagnostics;

namespace Image_14
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void CarregaImagem(object sender, RoutedEventArgs e)
        {
            Image imgAux = sender as Image;
            if (imgAux != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                Uri uriBandeiras = new System.Uri("ms-appx:///Image/brasil.jpg");
                bitmapImage.UriSource = uriBandeiras;
                imgAux.Source = bitmapImage;

                MinhaImagem.Height = 100;
                MinhaImagem.Width = 100;
            }
        }
    }
}
