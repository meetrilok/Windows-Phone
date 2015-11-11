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

using Windows.Media.Capture;            
using Windows.Media.MediaProperties;    
using Windows.Storage;                  
using Windows.UI.Xaml.Media.Imaging;    

namespace Camera_01
{
    public sealed partial class MainPage : Page
    {
        Windows.Media.Capture.MediaCapture GerenteCaptura;       

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        async private void IniciaPreviaCapturaFoto (object sender, RoutedEventArgs e)
        {
            GerenteCaptura = new Windows.Media.Capture.MediaCapture();
            await GerenteCaptura.InitializeAsync();

            GerenteCaptura.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
            CapturaPrevia.Source = GerenteCaptura;
            await GerenteCaptura.StartPreviewAsync();
        }

        async private void ParaPreviaCapturaFoto(object sender, RoutedEventArgs e)
        {
            await GerenteCaptura.StopPreviewAsync();   
        }

        async private void CapturaFoto(object sender, RoutedEventArgs e)
        {
            ImageEncodingProperties imgFormato = ImageEncodingProperties.CreateJpeg();
            StorageFile ArquivoImagem = await KnownFolders.PicturesLibrary.CreateFileAsync("MinhaFoto.jpg", CreationCollisionOption.GenerateUniqueName);

            await GerenteCaptura.CapturePhotoToStorageFileAsync(imgFormato, ArquivoImagem);
            BitmapImage bmpImagem = new BitmapImage(new Uri(ArquivoImagem.Path));
            imagePreivew.Source = bmpImagem;

        }

    }
}
