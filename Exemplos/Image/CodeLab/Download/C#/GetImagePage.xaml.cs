using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Windows.Media.Imaging;

namespace HTTPRequests
{
    public partial class GetImagePage : PhoneApplicationPage
    {
        private HttpWebRequest webRequest;
        private const string imageUrl = "https://www.developer.nokia.com/pics/wp_main_lumia.png";

        public GetImagePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            DownloadStatusText.Text = "Downloading image from " + imageUrl;
            webRequest = (HttpWebRequest)HttpWebRequest.CreateHttp(imageUrl);
            webRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), webRequest);

            base.OnNavigatedTo(e);
        }

        private void ResponseCallback(IAsyncResult asyncResult)
        {
           webRequest = (HttpWebRequest)asyncResult.AsyncState;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult);
            
            MemoryStream tempStream = new MemoryStream();
            webResponse.GetResponseStream().CopyTo(tempStream);

            Dispatcher.BeginInvoke(() =>
                {
                    BitmapImage image = new BitmapImage();
                    image.CreateOptions = BitmapCreateOptions.None;
                    image.SetSource(tempStream);

                    DownloadResultImage.Source = image;
                    DownloadStatusText.Text = "Download completed.";
                });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webRequest.Abort();
        }
    }
}