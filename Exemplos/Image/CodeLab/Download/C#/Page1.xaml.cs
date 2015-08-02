using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Resources;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace HTTPRequests
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var webClient = new WebClient();
            webClient.OpenReadCompleted += WebClientOpenReadCompleted;
            webClient.OpenReadAsync(new Uri("https://s3-eu-west-1.amazonaws.com/s3.namy.net/chat/14/sample_photo_08_5273735c1879f.jpg", UriKind.Absolute));
        }
        void WebClientOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            const string tempJpeg = "TempJPEG";
            var streamResourceInfo = new StreamResourceInfo(e.Result, null);

            var userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStoreForApplication.FileExists(tempJpeg))
            {
                userStoreForApplication.DeleteFile(tempJpeg);
            }

            var isolatedStorageFileStream = userStoreForApplication.CreateFile(tempJpeg);

            var bitmapImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            bitmapImage.SetSource(streamResourceInfo.Stream);

            var writeableBitmap = new WriteableBitmap(bitmapImage);
            writeableBitmap.SaveJpeg(isolatedStorageFileStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 85);

            isolatedStorageFileStream.Close();
            isolatedStorageFileStream = userStoreForApplication.OpenFile(tempJpeg, FileMode.Open, FileAccess.Read);

            // Save the image to the camera roll or saved pictures album.
            var mediaLibrary = new MediaLibrary();

            // Save the image to the saved pictures album.
            mediaLibrary.SavePicture(string.Format("SavedPicture{0}.jpg", DateTime.Now), isolatedStorageFileStream);

            isolatedStorageFileStream.Close();
        }
    }
}