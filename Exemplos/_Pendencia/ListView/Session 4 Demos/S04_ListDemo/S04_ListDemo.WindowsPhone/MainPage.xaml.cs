﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace S04_ListDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
        }

        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListViewPage));
        }

        private void GridView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GridViewPage));
        }

        private void GroupedListView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GroupedListViewPage));
        }

        private void GroupedGridView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GroupedGridView));
        }

        private void GiantList_Click(object sender, RoutedEventArgs e)
        {
            App.PopulateGiantList();
            this.Frame.Navigate(typeof(GroupedListViewPage));
        }
    }
}
