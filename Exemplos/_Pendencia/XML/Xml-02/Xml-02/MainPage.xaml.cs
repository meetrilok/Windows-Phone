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


// EXCELENTE EXMPLO TENHO SO QUE RESOLVER A QUESTAO DO WEBCLIENT QUE FOI SUBSTITUIDO POR HTTPCLIENT
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace Xml_02
{
    public sealed partial class MainPage : Page
    {
        public static List<Author> authors = new List<Author>();

        public class Author
        {
            public string name { get; set; }
            public int count { get; set; }
            public int likes { get; set; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
