using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContosoCookbook.Resources;
using ContosoCookbook.Data;

namespace ContosoCookbook
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            LocalizeApplicationBar();
        }


        private Microsoft.Phone.Shell.ProgressIndicator pi;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!App.Recipes.IsLoaded)
            {
                pi = new Microsoft.Phone.Shell.ProgressIndicator();
                pi.IsIndeterminate = true;
                pi.Text = "Loading data, please wait...";
                pi.IsVisible = true;

                Microsoft.Phone.Shell.SystemTray.SetIsVisible(this, true);
                Microsoft.Phone.Shell.SystemTray.SetProgressIndicator(this, pi);

                App.Recipes.RecipesLoaded += Recipes_RecipesLoaded;
                App.Recipes.LoadLocalDataAsync();
            }
            base.OnNavigatedTo(e);
        }

        void Recipes_RecipesLoaded(object sender, EventArgs e)
        {
            lstGroups.DataContext = App.Recipes;

            pi.IsVisible = false;
            Microsoft.Phone.Shell.SystemTray.SetIsVisible(this, false);
        }

        private void lstGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGroups.SelectedItem != null)
            {
                NavigationService.Navigate(new Uri("/GroupDetailPage.xaml?ID=" + 
                    (lstGroups.SelectedItem as RecipeDataGroup).UniqueId, UriKind.Relative));
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
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

        private void LocalizeApplicationBar()
        {
            ApplicationBarMenuItem aboutMenuItem = ApplicationBar.MenuItems[0] as ApplicationBarMenuItem;
            aboutMenuItem.Text = AppResources.AboutMenuItemText;
        }
    }
}