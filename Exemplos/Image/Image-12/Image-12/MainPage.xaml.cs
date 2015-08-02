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
// Insercao Obrigatoria
// ====================================================================

using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Display;

namespace Image_12
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            Uri uriBandeiras = null;
            Image imgBandeira = new Image();
            BitmapImage bitmapImage = new BitmapImage();

            switch ( DisplayProperties.ResolutionScale )
            {
                case    ResolutionScale.Scale100Percent :
                        uriBandeiras = new System.Uri ("ms-appx:///Images/scale-100/Bandeira.png");
                        break;

                case    ResolutionScale.Scale140Percent :
                        uriBandeiras = new System.Uri ("ms-appx:///Images/scale-140/Bandeira.png");
                        break;

                case    ResolutionScale.Scale180Percent :
                        uriBandeiras = new System.Uri ("ms-appx:///Images/scale-180/Bandeira.png");
                        break;
            } 

            bitmapImage.UriSource = uriBandeiras;
            imgBandeira.Source = bitmapImage;
            imgFlag.Source = imgBandeira.Source;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
