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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace listview_from_json_tutorial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public class DataList
        {
            public string country { get; set; }
            public string code { get; set; }
        }


        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Loaded += new RoutedEventHandler(Page_Loaded);
        }


        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            download_data dwl = new download_data();

            dwl.downloadDatacomplete += data_arrived;
            dwl.get_data("http://www.kaleidosblog.com/tutorial/tutorial.json");
        }


        void data_arrived(object sender, DownloadCompleteData e)
        {

            String data = e.data;

            JArray obj = JArray.Parse(data);

            for (int i = 0; i < obj.Count; i++)
            {

                JObject row = JObject.Parse(obj[i].ToString());

                var item = new DataList();
                item.country = row["country"].ToString();
                item.code = row["code"].ToString();

                list.Items.Add(item);
            }


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
    }
}
