using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Example81
{
    public sealed partial class MainPage : Page
    {
        Windows.Media.Capture.MediaCapture captureManager;

        public MainPage()
        {
            this.InitializeComponent();
            First.Click += async (sender, e) => await Initialize();
            Second.Click += (sender, e) => ViewFinder_OnTapped();
        }

        private async Task Initialize()
        {
            captureManager = new MediaCapture();

            await captureManager.InitializeAsync();
            capturePreview.Source = captureManager;
            await captureManager.StartPreviewAsync();
        }

        private async void ViewFinder_OnTapped()
        {
            ImageEncodingProperties imageProperties = ImageEncodingProperties.CreateJpeg();

            var stream = new InMemoryRandomAccessStream();

            await captureManager.CapturePhotoToStreamAsync(imageProperties, stream);

            _bitmap = new WriteableBitmap(300, 300);
            stream.Seek(0);
            await _bitmap.SetSourceAsync(stream);

            stream.Seek(0);
            var buffer = new global::Windows.Storage.Streams.Buffer((uint)stream.Size);
            stream.ReadAsync(buffer, (uint)stream.Size, InputStreamOptions.None);
            await captureManager.StopPreviewAsync();
        }


        public WriteableBitmap _bitmap { get; set; }
    }
}
