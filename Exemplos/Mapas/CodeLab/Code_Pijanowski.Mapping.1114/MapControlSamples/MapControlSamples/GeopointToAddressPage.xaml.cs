using MapControlSamples.Common;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace MapControlSamples
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class GeopointToAddressPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public GeopointToAddressPage()
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Call the navigation helper base function.
            this.navigationHelper.OnNavigatedTo(e);

            // Get the user's current location.
            Geolocator geolocator = new Geolocator();
            Geoposition geoposition = null;
            try
            {
                geoposition = await geolocator.GetGeopositionAsync();
            }
            catch (Exception)
            {
                // Make sure you have defined ID_CAP_LOCATION in the application manifest 
                // and that on your phone, you have turned on location by checking 
                // Settings > Location.

                // Handle errors like unauthorized access to location services
            }

            // Set the map center point.
            myMapControl.Center = geoposition.Coordinate.Point;

            // add a custom image to represent the current location
            addImageToMap(geoposition.Coordinate.Point);

            // display the address of the current locaiton
            await displayAddress(geoposition.Coordinate.Point);

            // Zoom level
            myMapControl.ZoomLevel = 15;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void mcShowLocation_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            // add the image
            addImageToMap(args.Location);

            // display the address
            await displayAddress(args.Location);
        }

        private void addImageToMap(Geopoint geopoint)
        {
            // create an image
            Image image = new Image();
            image.Width = 40;
            image.Height = 40;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri("ms-appx:///Assets/PinkPushPin.png");
            image.Source = bitmapImage;
            MapControl.SetLocation(image, geopoint);
            MapControl.SetNormalizedAnchorPoint(image, new Point(0.25, 0.9));

            // clear existing children then add the image
            myMapControl.Children.Clear();
            myMapControl.Children.Add(image);
        }

        private async Task displayAddress(Geopoint geopoint)
        {
            // find the address of the tapped location
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(geopoint);

            // If successful then display the address.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                if (result.Locations.Count > 0)
                {
                    string display;
                    if (string.IsNullOrEmpty(result.Locations[0].Address.Street))
                    {
                        display = result.Locations[0].Address.Town + ", " +
                            result.Locations[0].Address.Region;
                    }
                    else
                    {
                        display = result.Locations[0].Address.StreetNumber + " " +
                            result.Locations[0].Address.Street;
                    }

                    tbAddress.Text = display;
                }
                else
                {
                    string msg = this.resourceLoader.GetString("NoAddress");
                    tbAddress.Text = msg;
                }
            }

        }

        private void sbTraffic_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (myMapControl.TrafficFlowVisible)
            {
                myMapControl.TrafficFlowVisible = false;
                string label = this.resourceLoader.GetString("ShowTrafficFlow");
                sbTraffic.Label = label;
            }
            else
            {
                myMapControl.TrafficFlowVisible = true;
                string label = this.resourceLoader.GetString("TurnOffTrafficFlow");
                sbTraffic.Label = label;
            }

        }

        private void sbPedestrianFeatures_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (myMapControl.PedestrianFeaturesVisible)
            {
                myMapControl.PedestrianFeaturesVisible = false;
                string label = this.resourceLoader.GetString("ShowPedestrianFeatures");
                sbPedestrianFeatures.Label = label;
            }
            else
            {
                myMapControl.PedestrianFeaturesVisible = true;
                string label = this.resourceLoader.GetString("TurnOffPedestrianFeatures");
                sbPedestrianFeatures.Label = label;
            }
        }

        private void sbLandmarks_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (myMapControl.LandmarksVisible)
            {
                myMapControl.LandmarksVisible = false;
                string label = this.resourceLoader.GetString("ShowLandmarks");
                sbLandmarks.Label = label;
            }
            else
            {
                myMapControl.LandmarksVisible = true;
                string label = this.resourceLoader.GetString("TurnOffLandmarks");
                sbLandmarks.Label = label;
            }
        }

    }
}