using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XML_Parsing.Resources;
using System.Windows.Resources;
using System.Xml.Linq;
using System.IO;

namespace XML_Parsing
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public class Author
        {
            public string name { get; set; }
            public int count { get; set; }
            public int likes { get; set; }
        }
        public static List<Author> authors = new List<Author>();
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += client_OpenReadCompleted;
            client.OpenReadAsync(new Uri("http://theindianumbrella.com/apps/quotes/webservices/getAllAuthors.php", UriKind.Absolute));
        }
        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
            Stream str = e.Result;
            try
            {
                String eve = "author";
                XDocument loadedData = XDocument.Load(str);
                foreach (var item in loadedData.Descendants(eve))
                {

                    try
                    {
                        Author c = new Author();
                        c.name = item.Element("name").Value;
                        c.count = Convert.ToInt32(item.Element("count").Value);
                        c.likes = Convert.ToInt32(item.Element("voting").Value);
                        authors.Add(c);
                    }
                    catch (Exception ex)
                    {
                        //GoogleAnalytics.EasyTracker.GetTracker().SendException(ex.Message, false);
                    }
                }
                authorlistbox.ItemsSource = authors;
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show("limited connectivity or invalid data.\nplease try again");
            }
        }
        private void loadPopularAuthors()
        {
            StreamResourceInfo strm = Application.GetResourceStream(new Uri("getAllAuthors.xml", UriKind.Relative));
            try
            {
                String eve = "author";
                XDocument loadedData = XDocument.Load(strm.Stream);
                foreach (var item in loadedData.Descendants(eve))
                {

                    try
                    {
                        Author c = new Author();
                        c.name = item.Element("name").Value;
                        c.count = Convert.ToInt32(item.Element("count").Value);
                        c.likes = Convert.ToInt32(item.Element("voting").Value);
                        authors.Add(c);
                    }
                    catch (Exception ex)
                    {
                        //GoogleAnalytics.EasyTracker.GetTracker().SendException(ex.Message, false);
                    }
                }
                authorlistbox.ItemsSource = authors;
            }
            catch (Exception ex)
            {
               // GoogleAnalytics.EasyTracker.GetTracker().SendException(ex.Message, false);
            }
        }
    }
}