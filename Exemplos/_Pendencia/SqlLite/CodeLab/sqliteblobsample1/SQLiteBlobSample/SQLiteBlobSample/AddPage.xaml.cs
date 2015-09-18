using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using SQLiteBlobSample.ViewModels;

namespace SQLiteBlobSample
{
    public partial class AddPage : PhoneApplicationPage
    {
        private Microsoft.Phone.Tasks.PhotoChooserTask photoChooser = null;

        public AddPage()
        {
            InitializeComponent();

            photoChooser = new PhotoChooserTask();
            photoChooser.Completed += photoChooser_Completed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                photoChooser.ShowCamera = true;
                photoChooser.Show();
            }
        }

        async void photoChooser_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bitmapSource = new BitmapImage();
                bitmapSource.SetSource(e.ChosenPhoto);
                this.picImage.Source = bitmapSource;
            }
            else
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            try
            {
                await PicturesViewModel.GetDefault().InsertItemAsync(
                    new PictureViewModel(-1, this.CaptionTextBox.Text, this.picImage.Source as BitmapImage));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception on Insert: " + ex.Message);
            }

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}