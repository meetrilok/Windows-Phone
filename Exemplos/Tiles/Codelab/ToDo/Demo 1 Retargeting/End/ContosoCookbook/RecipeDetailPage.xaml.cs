using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using ContosoCookbook.Data;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using ContosoCookbook.Resources;
using ContosoCookbook.Common;


namespace ContosoCookbook
{
    public partial class RecipeDetailPage : PhoneApplicationPage
    {
        private RecipeDataItem item;
        private const string removeFavUri = "/Assets/Icons/unlike.png";
        private const string FavUri = "/Assets/Icons/like.png";

        public RecipeDetailPage()
        {
            InitializeComponent();

            camera = new CameraCaptureTask();
            camera.Completed += camera_Completed;

            LocalizeApplicationBar();
        }

        void camera_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //Code to display the photo on the page in an image control named myImage.
                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                bmp.SetSource(e.ChosenPhoto);

                using (System.IO.IsolatedStorage.IsolatedStorageFile isoStore = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!isoStore.DirectoryExists(item.Group.Title))
                        isoStore.CreateDirectory(item.Group.Title);

                    string fileName = string.Format("{0}/{1}.jpg", item.Group.Title, DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));

                    using (System.IO.IsolatedStorage.IsolatedStorageFileStream targetStream = isoStore.CreateFile(fileName))
                    {
                        WriteableBitmap wb = new WriteableBitmap(bmp);
                        wb.SaveJpeg(targetStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                        targetStream.Close();
                    }

                    if (null == item.UserImages)
                        item.UserImages = new System.Collections.ObjectModel.ObservableCollection<string>();

                    item.UserImages.Add(fileName);
                }
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.Recipes.IsLoaded)
            {
                await App.Recipes.LoadLocalDataAsync();
            }

            string UniqueId = NavigationContext.QueryString["ID"];

            if (!App.Recipes.IsLoaded)
                await App.Recipes.LoadLocalDataAsync();

            item = App.Recipes.FindRecipe(UniqueId);
            pivot.DataContext = item;

            PositionForOrientation();

            SetPinBar();

            base.OnNavigatedTo(e);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Aboutpage.xaml", UriKind.Relative));
        }

        CameraCaptureTask camera;

        private void PhotoAppBarButton_Click(object sender, EventArgs e)
        {
            try
            {
                camera.Show();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred.");
            }
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            PositionForOrientation();
        }

        private void PositionForOrientation()
        {
            if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                DirectionsScrollViewer.SetValue(Grid.RowProperty, 1);
                DirectionsScrollViewer.SetValue(Grid.ColumnProperty, 1);
                DirectionsScrollViewer.Margin = new Thickness(12, 0, 0, 0);
                DirectionsTextBlock.MaxWidth = 400;
                RecipeGrid.Margin = new Thickness(12, -24, 0, 0);
            }
            else
            {
                DirectionsScrollViewer.SetValue(Grid.RowProperty, 2);
                DirectionsScrollViewer.SetValue(Grid.ColumnProperty, 0);
                DirectionsScrollViewer.Margin = new Thickness(0, 0, 0, 0);
                DirectionsTextBlock.MaxWidth = 480;
                RecipeGrid.Margin = new Thickness(12, 0, 0, 0);
            }
        }

        private void LocalizeApplicationBar()
        {
            ApplicationBarIconButton photoButton = ApplicationBar.Buttons[0] as ApplicationBarIconButton;
            photoButton.Text = AppResources.PhotoAppBarButtonText;

            ApplicationBarMenuItem aboutMenuItem = ApplicationBar.MenuItems[0] as ApplicationBarMenuItem;
            aboutMenuItem.Text = AppResources.AboutMenuItemText;
        }

        private void btnPinToStart_Click(object sender, EventArgs e)
        {
            var uri = NavigationService.Source.ToString();
            if (Features.Tile.TileExists(uri))
            {
                Features.Tile.DeleteTile(uri);
            }
            else
            {
                Features.Tile.SetTile(item, uri);
            }

            SetPinBar();
        }

        public ApplicationBarIconButton pinBtn
        {
            get
            {
                var appBar = (ApplicationBar)ApplicationBar;
                var count = appBar.Buttons.Count;
                for (var i = 0; i < count; i++)
                {
                    ApplicationBarIconButton btn = appBar.Buttons[i] as ApplicationBarIconButton;
                    if (btn.IconUri.OriginalString.Contains("like"))
                        return btn;
                }
                return null;
            }
        }

        void SetPinBar()
        {
            var uri = NavigationService.Source.ToString();
            if (Features.Tile.TileExists(uri))
            {
                pinBtn.IconUri = new Uri(removeFavUri, UriKind.Relative);
                pinBtn.Text = "Unpin";
            }
            else
            {
                pinBtn.IconUri = new Uri(FavUri, UriKind.Relative);
                pinBtn.Text = "Pin";
            }
        }
    }
}