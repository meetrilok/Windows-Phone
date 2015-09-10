using MapControlSamples.Common;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MapControlSamples
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class AddressToGeopointPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public AddressToGeopointPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        } 

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private void tbAddress_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                geocode(tbAddress.Text);
            }
        }

        private async void geocode(string address)
        {
            // Get the user's current location so it can be used as a starting point 
            // for the location search below.
            Geolocator geolocator = new Geolocator();
            Geoposition currentPosition = await geolocator.GetGeopositionAsync();

            // Geocodes the specified address, using the current location
            // as a reference point. Returns no more than 5 results.
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAsync(
                                    address,
                                    currentPosition.Coordinate.Point,
                                    5);

            // list to hold search results
            List<string> locations = new List<string>();

            // If the query returns results then bind it to the list view.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                foreach (MapLocation mapLocation in result.Locations)
                {
                    // create a display string of the map location
                    string display = mapLocation.Address.StreetNumber + " " +
                        mapLocation.Address.Street + Environment.NewLine +
                        mapLocation.Address.Town + ", " +
                        mapLocation.Address.RegionCode + "  " +
                        mapLocation.Address.PostCode + Environment.NewLine +
                        mapLocation.Address.CountryCode;

                    // add the display string to the location list
                    locations.Add(display);
                }

                // bind the location list to the ListView control
                lvLocations.ItemsSource = locations;

            }
            else
            {
                // Tell the user to try again.
                string message = this.resourceLoader.GetString("NoAddress");
                MessageDialog messageDialog = new MessageDialog(message);
                await messageDialog.ShowAsync();
            }

            if (locations.Count == 0)
            {
                // Tell the user to try again.
                string message = this.resourceLoader.GetString("NoAddress");
                string title = this.resourceLoader.GetString("NoAddressTitle");
                MessageDialog messageDialog = new MessageDialog(message,title);
                await messageDialog.ShowAsync();
            }
        }


        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>.
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

    }
}