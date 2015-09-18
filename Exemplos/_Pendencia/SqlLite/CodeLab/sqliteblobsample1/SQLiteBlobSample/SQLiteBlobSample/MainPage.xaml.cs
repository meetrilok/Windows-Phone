using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLiteBlobSample.Resources;
using SQLiteBlobSample.ViewModels;

namespace SQLiteBlobSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        PicturesViewModel viewModel;
        DateTime timestamp = DateTime.MinValue;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (viewModel != null && timestamp >= viewModel.Timestamp)
                return;

            LoadData();

            timestamp = DateTime.Now;
        }

        private async void LoadData()
        {
            viewModel = PicturesViewModel.GetDefault();
            PicturesList.ItemsSource = await viewModel.GetAllItems();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPage.xaml", UriKind.Relative));
        }
    }
}