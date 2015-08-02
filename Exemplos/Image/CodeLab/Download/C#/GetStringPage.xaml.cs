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
using System.Windows.Media.Imaging;
using System.IO;

namespace HTTPRequests
{
    public partial class GetStringPage : PhoneApplicationPage
    {
        private WebClient webClient;
        private string downloadUrl = "https://s3-eu-west-1.amazonaws.com/s3.namy.net/chat/14/1_5278dad6e5781.JPG?r=" + System.DateTime.Now;

        public GetStringPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadStringAsync(new Uri(downloadUrl));

            DownloadStatusText.Text = "Downloading source from " + downloadUrl;
            DownloadResultText.Text = string.Empty;

            base.OnNavigatedTo(e);
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            test.Value = e.BytesReceived;
            //test.Value = e.ProgressPercentage;
            test.Maximum = e.TotalBytesToReceive;
            DownloadResultText.Text = "Downloaded " + e.BytesReceived + "/" + e.TotalBytesToReceive + "bytes, " + e.ProgressPercentage + "% completed.";
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == true)
                {
                    DownloadStatusText.Text = "Download cancelled.";
                    return;
                }

                if (e.Error != null)
                {
                    DownloadStatusText.Text = "Download error.";
                    DownloadResultText.Text = e.Error.ToString();
                    return;
                }

                DownloadStatusText.Text = "Download completed.";
                DownloadResultText.Text = e.Result;
                BitmapImage image = new BitmapImage(new Uri("" + downloadUrl));
                DownloadResultImage.Source = image;
                DownloadStatusText.Text = "Download completed.";
                DownloadResultText.Visibility = Visibility.Collapsed;
                cancelbtn.Visibility = Visibility.Collapsed;
            }
            catch
            {
            }

        }

        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {
            webClient.CancelAsync();
        }

    }
    
}