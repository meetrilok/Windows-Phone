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

using Windows.Media.Capture;            //For MediaCapture
using Windows.Media.MediaProperties;    //For Encoding Image in JPEG format
using Windows.Storage;                  //For storing Capture Image in App storage or in Picture Library
using Windows.UI.Xaml.Media.Imaging;    //For BitmapImage. for showing image on screen we need BitmapImage format.

namespace Camera_01
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        //Declare MediaCapture object globally
        Windows.Media.Capture.MediaCapture captureManager;


        async private void Start_Capture_Preview_Click(object sender, RoutedEventArgs e)
        {
            captureManager = new MediaCapture();        //Define MediaCapture object
            await captureManager.InitializeAsync();     //Initialize MediaCapture and 
            capturePreview.Source = captureManager;     //Start preiving on CaptureElement
            await captureManager.StartPreviewAsync();   //Start camera capturing 
        }

        async private void Stop_Capture_Preview_Click(object sender, RoutedEventArgs e)
        {
            await captureManager.StopPreviewAsync();   
        }

        async private void Capture_Photo_Click(object sender, RoutedEventArgs e)
        {
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
            StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpg", CreationCollisionOption.GenerateUniqueName);
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
            imagePreivew.Source = bmpImage;

        }

    }
}
