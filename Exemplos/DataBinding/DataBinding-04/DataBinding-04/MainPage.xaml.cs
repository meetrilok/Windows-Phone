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

namespace DataBinding_04
{

    public sealed partial class MainPage : Page
    {
        public class Sampleclass
        {
            public string mytext 
            { 
                get; 
                set; 
            }

        }

        public MainPage()
        {
            Sampleclass obj = new Sampleclass();
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            obj.mytext = "One way data binding";
            myblock.DataContext = obj;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
