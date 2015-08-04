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


//  for xml parsing
using System.Xml.Linq;
using System.ComponentModel;


namespace FlickrWP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        object selectedItem;
        Uri targetPage;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void FlickrSearch_Click(object sender, RoutedEventArgs e)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webclient_DownloadStringCompleted);
            webclient.DownloadStringAsync(new Uri("http://api.flickr.com/services/feeds/photos_public.gne?tag=" + SearchBox.Text + "&format=rss2")); // Flickr search
        }
        void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("error");

            }

           


            // parsing Flickr 

            XElement XmlTweet = XElement.Parse(e.Result);
            //var ns = XmlTweet.GetDefaultNamespace(); // get the default namespace
            XNamespace ns = "http://search.yahoo.com/mrss/";
            listBox1.ItemsSource = from tweet in XmlTweet.Descendants("item")
                                   select new FlickrData
                                   {

                                       ImageSource = tweet.Element(ns + "thumbnail").Attribute("url").Value,
                                       Message = tweet.Element("description").Value,
                                       UserName = tweet.Element("title").Value,
                                       PubDate = DateTime.Parse(tweet.Element("pubDate").Value)
                                   };




        }
        private void Tap_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel rect = sender as StackPanel;
            // Change the size of the Rectangle.
            if (null != rect)
            {
                rect.Opacity = 0.5;


            }
        }
        private void Tap_LeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel rect = sender as StackPanel;
            // Reset the dimensions on the Rectangle.
            if (null != rect)
            {
                rect.Opacity = 1.0;

            }
        }
        private void Tap_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel rect = sender as StackPanel;
            // Finger moved out of Rectangle before the mouse up event.
            // Reset the dimensions on the Rectangle.


            if (null != rect)
            {
                rect.Opacity = 1.0;

            }
        }
        private void listBoxFlickerSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                // get RSS item from ListBox and store in class var. Store page to navigate to in class var.
                selectedItem = (FlickrData)e.AddedItems[0];
                targetPage = new Uri("/FlickrDetail.xaml", UriKind.Relative);

                // reset selection of ListBox
                ((ListBox)sender).SelectedIndex = -1;

                // PageTransition.Begin();

                // change  page navigation 
                NavigationService.Navigate(targetPage);
                FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
                root.DataContext = selectedItem;
            }
        }

    }
}