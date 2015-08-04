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

namespace FlickrWP7
{

    public class FlickrDetailPage
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public string ImageSource { get; set; }
        public DateTime PubDate { get; set; }
    }

    public partial class FlickrDetail : PhoneApplicationPage
    {
        public FlickrDetail()
        {
            InitializeComponent();
            //added
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            this.Loaded += new RoutedEventHandler(RssItemPage_Loaded);
           // PageTransition.Completed += new EventHandler(PageTransition_Completed);
        }

        #region Event Handlers
        void RssItemPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            // Set page title to news title and navigate to string containing news item.
          //  PageTitle.Text = ((RssItem)DataContext).Title.ToLower();


            FlickrDetailPage iFlickrDetail = new FlickrDetailPage();
            iFlickrDetail.UserName = ((FlickrData )DataContext).UserName.ToLower();
            iFlickrDetail.ImageSource = ((FlickrData)DataContext).ImageSource.ToLower();
            iFlickrDetail.PubDate = ((FlickrData)DataContext).PubDate;
            iFlickrDetail.Message = ((FlickrData)DataContext).Message.ToLower();
            listBoxFlickrDetail.Items.Add(iFlickrDetail);


            // ContentName.Text = ((RssItem)DataContext).Title.ToLower();
            //   image1.Source = ((RssItem)DataContext).Media.ToLower();


        }
        
        #endregion
    }
}