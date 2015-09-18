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
    public sealed partial class GridViewPage : Page
    {
        public GridViewPage()
        {
            this.InitializeComponent();
            this.DataContext = App.AppDataSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)

                this.Frame.GoBack();

        }


        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SampleGridView.CanReorderItems)
            {
                SampleGridView.CanReorderItems = false;
                SampleGridView.AllowDrop = false;
                SampleGridView.CanDragItems = false;

            }
            else
            {
                SampleGridView.CanReorderItems = true;
                SampleGridView.AllowDrop = true;
                SampleGridView.CanDragItems = true;
            }
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (SampleGridView.SelectionMode == ListViewSelectionMode.Single)
                SampleGridView.SelectionMode = ListViewSelectionMode.Multiple;
            else
                SampleGridView.SelectionMode = ListViewSelectionMode.Single;
        }
    }
}
