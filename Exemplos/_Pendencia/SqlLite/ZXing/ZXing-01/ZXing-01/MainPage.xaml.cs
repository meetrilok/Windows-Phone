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
using ZXing;                            // Inserir
using Windows.UI.Xaml.Media.Imaging;    // Inserir

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ZXing_01
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
            IBarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,//Mentioning type of bar code generation  
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 300,
                    Width = 300
                },
                Renderer = new ZXing.Rendering.PixelDataRenderer() { Foreground = Windows.UI.Colors.Black }//Adding color QR code  
            };
            var result = writer.Write("http://www.bsubramanyamraju.blogspot.com ");
            var wb = result.ToBitmap() as WriteableBitmap;
            //Displaying QRCode Image  
            QrCodeImg.Source = wb;
        }  
    }
}
