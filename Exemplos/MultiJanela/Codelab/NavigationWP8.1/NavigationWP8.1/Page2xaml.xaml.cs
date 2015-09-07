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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NavigationWP8._1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2xaml : Page
    {
        public Page2xaml()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Taking the Parameter recieved by NavigationEventArgs e
           // paramTextBlock.Text = e.Parameter.ToString();

            //creating a var type variable and save the object parameter from page 1
            //and typecasting it with the Class we have created
            var myObject = (Class1) e.Parameter;
            paramTextBlock.Text = myObject.data1;
            //we can also use other information or data from the class 
            //like 
           // paramTextBlock.Text = myObject.data2.ToString();


        }
    }
}
