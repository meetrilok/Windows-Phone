using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml;
using System.Xml.Linq;
using Windows.UI;
using System.Net;
using System.Windows;
using Comic.Common;
//using Microsoft.Phone.Net.NetworkInformation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Comic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        query t = new query();
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            

            loadlistbox();
        }

        
        
        void loadlistbox()
        {
            lstcomic.ItemsSource = t.thandongdatviet();
        }
       
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

       
        private void lstcomic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstcomic.SelectedIndex!=-1)
            {
                string value = (lstcomic.SelectedItem as data).name;
                this.Frame.Navigate(typeof(page2), value);
                
            }
        }
    }
}
