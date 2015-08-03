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
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.UI;
using Comic.Common;
using Windows.UI.Popups;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Comic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class page2 : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public page2()
        {
           
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
           
        }

        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            //throw new NotImplementedException();
        }
        
        public async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //throw new NotImplementedException();
            string value = e.NavigationParameter as string;
            if(!string.IsNullOrWhiteSpace(value))
            {
                query t = new query();
                object uri=t.loadurlpage(value);
                lstitem.ItemsSource = uri;
                //t(value);
                
            }
            else
            {

                var dialog = new MessageDialog("Loi khong co du lieu");
                await dialog.ShowAsync();
            }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }
    }
}
