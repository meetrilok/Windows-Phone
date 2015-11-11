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

using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;    


namespace Camera_03
{
    public sealed partial class MainPage : Page
    {
        Windows.Media.Capture.MediaCapture GerenteCaptura;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        async private void IniciaPreviaCapturaFoto(object sender, RoutedEventArgs e)
        {
            GerenteCaptura = new Windows.Media.Capture.MediaCapture();
            var cameraID = await GetCameraID(Windows.Devices.Enumeration.Panel.Front);

            await GerenteCaptura.InitializeAsync(new MediaCaptureInitializationSettings
            {
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.Photo,
                AudioDeviceId = string.Empty,
                VideoDeviceId = cameraID.Id,
            });

            GerenteCaptura.SetPreviewRotation(VideoRotation.Clockwise270Degrees);
            CapturaPrevia.Source = GerenteCaptura;
            await GerenteCaptura.StartPreviewAsync();
        }

        async private void ParaPreviaCapturaFoto(object sender, RoutedEventArgs e)
        {
            await GerenteCaptura.StopPreviewAsync();
        }

        #region Focus Helpers

        private static async Task<DeviceInformation> GetCameraID(Windows.Devices.Enumeration.Panel camera)
        {
            DeviceInformation deviceID = (await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture))
                .FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == camera);

            return deviceID;
        }


        private async void SetFocus(uint? focusValue = null)
        {
            try
            {
                if (!focusValue.HasValue)
                {
                    focusValue = 500;
                }

                if (GerenteCaptura.VideoDeviceController.FocusControl.Supported)
                {
                    GerenteCaptura.VideoDeviceController.FlashControl.AssistantLightEnabled = false;
                    GerenteCaptura.VideoDeviceController.FocusControl.Configure(new FocusSettings() { Mode = FocusMode.Manual, Value = focusValue, DisableDriverFallback = true });
                    await GerenteCaptura.VideoDeviceController.FocusControl.FocusAsync();
                }
            }
            catch { }
        }

        private void AlteraFoco(object sender, RangeBaseValueChangedEventArgs e)
        {
            try
            {
                uint focus = Convert.ToUInt32(e.NewValue);
                SetFocus(focus);
            }
            catch
            {

            }
        }

        #endregion

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