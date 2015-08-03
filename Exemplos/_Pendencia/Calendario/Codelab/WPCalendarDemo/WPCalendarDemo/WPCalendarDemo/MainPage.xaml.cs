using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPCalendarDemo.Resources;
using Microsoft.Phone.UserData;

namespace WPCalendarDemo
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

        private void buttonSearchAppointments_Click(object sender, RoutedEventArgs e)
        {
            
            Appointments appointments = new Appointments();
            appointments.SearchCompleted += appointments_SearchCompleted;
            
            appointments.SearchAsync(DateTime.Today, DateTime.Today.AddDays(1), "All appointments today");
        }

        void appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {
            listBoxSearchResults.DataContext = null;
            listBoxSearchResults.Items.Clear();
            if (textBoxSubject.Text.Trim() == "" || textBoxSubject.Text == "Enter subject here")
            {
                listBoxSearchResults.DataContext = e.Results;
            }
            else
            {
                foreach (Appointment a in e.Results)
                {
                    if(a.Subject.Contains(textBoxSubject.Text.Trim()))
                    {
                        listBoxSearchResults.Items.Add(a);
                    }
                }
            }
            
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