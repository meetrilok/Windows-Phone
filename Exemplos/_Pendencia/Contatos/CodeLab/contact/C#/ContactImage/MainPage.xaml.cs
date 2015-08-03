using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContactImage.Resources;
using Microsoft.Phone.UserData;

namespace ContactImage
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        private void GetContactPictures_Click(object sender, RoutedEventArgs e)
        {
            Contacts cons = new Contacts();

            //Identify the method that runs after the asynchronous search completes.
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted_Many);

            //Start the asynchronous search.
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #3 Picture");
        }

        void Contacts_SearchCompleted_Many(object sender, ContactsSearchEventArgs e)
        {
            try
            {
                //Bind the results to the list box that displays them in the UI.
                ContactResultsData.DataContext = e.Results;
            }
            catch (System.Exception)
            {
                //No results
            }
        }
    }
}