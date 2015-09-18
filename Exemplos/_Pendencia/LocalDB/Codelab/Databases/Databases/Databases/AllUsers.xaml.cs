using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Databases
{
    public partial class AllUsers : PhoneApplicationPage
    {
        public AllUsers()
        {
            InitializeComponent();
            FetchDatabase fetch = new FetchDatabase();
            allusers.ItemsSource = fetch.getUsers();
        }
    }
}