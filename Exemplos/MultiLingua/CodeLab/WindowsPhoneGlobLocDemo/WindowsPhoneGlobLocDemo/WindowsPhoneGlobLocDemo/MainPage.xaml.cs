using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsPhoneGlobLocDemo.Resources;
using System.Globalization;
using System.Threading;

namespace WindowsPhoneGlobLocDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void radioButtonenUS_Checked(object sender, RoutedEventArgs e)
        {
            ApplyCulture(new CultureInfo("en-US"));
        }

        private void ApplyCulture(CultureInfo cul)
        {
            Thread.CurrentThread.CurrentCulture = cul;
            Thread.CurrentThread.CurrentUICulture = cul;
            DateTime current = DateTime.Now;
            textBoxLongDate.Text = current.ToString("D");
            textBoxShortDate.Text = current.ToString("d");
            textBoxTime.Text = current.ToString("T");
            textBoxCurrency.Text = 100.ToString("C");
            textBlockLongDate.Text = AppResources.TextLabelLongDate;
            textBlockShortDate.Text = AppResources.TextLabelShortDate;
            textBlockTime.Text = AppResources.TextLabelTime;
            textBlockCurrency.Text = AppResources.TextLabelCurrency;
            textBlockUser.Text = AppResources.UserName;
            textBlockHello.Text = AppResources.Salutation;
        }

        private void radiobuttonfrFR_Checked(object sender, RoutedEventArgs e)
        {
            ApplyCulture(new CultureInfo("fr-FR"));
            
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}