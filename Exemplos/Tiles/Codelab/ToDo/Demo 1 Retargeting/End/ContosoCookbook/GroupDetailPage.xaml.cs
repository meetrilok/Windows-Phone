using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContosoCookbook.Data;
using ContosoCookbook.Common;

namespace ContosoCookbook
{
    public partial class GroupDetailPage : PhoneApplicationPage
    {
        RecipeDataGroup group;
        private const string removeFavUri = "/Assets/Icons/unpin.png";
        private const string FavUri = "/Assets/Icons/pin.png";

        public GroupDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.Recipes.IsLoaded)
                await App.Recipes.LoadLocalDataAsync();

            if (NavigationContext.QueryString.ContainsKey("groupName"))
            {
                string groupName = NavigationContext.QueryString["groupName"];

                group = App.Recipes.FindGroupByName(groupName);
                pivot.DataContext = group;
            }
            else
            {
                string UniqueId = NavigationContext.QueryString["ID"];
                group = App.Recipes.FindGroup(UniqueId);
                pivot.DataContext = group;
            }

            PositionForOrientation();

            SetPinBar();

            //Update main tile with recently visited group
            Features.Tile.UpdateMainTile(group);

            base.OnNavigatedTo(e);
        }

        private void lstRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstRecipes.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(new Uri("/RecipeDetailPage.xaml?ID=" 
                    + (lstRecipes.SelectedItem as RecipeDataItem).UniqueId, UriKind.Relative));
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
                DescriptionScrollViewer.SetValue(Grid.RowProperty, 0);
                DescriptionScrollViewer.SetValue(Grid.ColumnProperty, 1);
                DescriptionScrollViewer.Margin = new Thickness(12, 0, 0, 0);
                PivotLayoutGrid.Margin = new Thickness(12, -24, 0, 0);
                PivotLayoutGrid.ColumnDefinitions[1].Width = new GridLength(1.0, GridUnitType.Star);
            }
            else
            {
                DescriptionScrollViewer.SetValue(Grid.RowProperty, 1);
                DescriptionScrollViewer.SetValue(Grid.ColumnProperty, 0);
                DescriptionScrollViewer.Margin = new Thickness(0, 0, 0, 0);
                PivotLayoutGrid.Margin = new Thickness(12, 0, 0, 0);
                PivotLayoutGrid.ColumnDefinitions[1].Width = new GridLength(0.0, GridUnitType.Pixel);
            }
        }

        private void btnPinToStart_Click(object sender, EventArgs e)
        {
            var uri = NavigationService.Source.ToString();
            if (Features.Tile.TileExists(uri))
            {
                // If the tile already exists, then we delete it
                Features.Tile.DeleteTile(uri);
            }
            else
            {
                // Otherwise create it
                Features.Tile.SetGroupTile(group, uri);
            }

            SetPinBar();
        }

        /// <summary>
        /// Method to find the ApplicationBarIconButton that is used for pin/unpin
        /// </summary>
        public ApplicationBarIconButton pinBtn
        {
            get
            {
                var appBar = (ApplicationBar)ApplicationBar;
                var count = appBar.Buttons.Count;
                for (var i = 0; i < count; i++)
                {
                    ApplicationBarIconButton btn = appBar.Buttons[i] as ApplicationBarIconButton;
                    if (btn.IconUri.OriginalString.Contains("pin"))
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