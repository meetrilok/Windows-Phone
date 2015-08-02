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
using System.Xml.Linq;
using System.IO;

namespace HTTPRequests
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Load();
        }

        private void Load()
        {
            //string ss = "<Categories><Cat Name='Allsav&apos;e' /><Cat Name='Missing Person at Risk' /><Cat Name='Stolen Vehicle' /><Cat Name='Missing Person' /><Cat Name='Chief s Message' /><Cat Name='Police Activity' /><Cat Name='School Notification' /><Cat Name='Wanted' /><Cat Name='Traffic Alert' /><Cat Name='Press Release' /><Cat Name='Miscellaneous' /><Cat Name='Traffic Bulletin' /></Categories>";
            // XDocument doc1 = XDocument.Load(new StringReader(ss));
            //foreach (var c in doc1.Descendants("Cat"))
            //{
            //  string test = c.Attribute("Name").Value.Trim();
            //    string test1=test;
            //}
           
        }

        private void GetImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GetStringPage.xaml", UriKind.Relative));
        }

        //private void GetImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/GetImagePage.xaml", UriKind.Relative));
        //}
    }
}