using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ListingContacts.Resources;
using ListingContacts.ViewModel;

namespace ListingContacts
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainPageViewModel dataContext;

        public MainPage()
        {
            InitializeComponent();

            dataContext = new MainPageViewModel();
            this.DataContext = dataContext;
        }

    }
}