using MapControlSamples.Common;
using System;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Navigation;

namespace MapControlSamples
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class DrivingRoutesPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public DrivingRoutesPage()
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
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // Start at Grand Central Station in New York City.
            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = 40.7517;
            startLocation.Longitude = -073.9766;
            Geopoint startPoint = new Geopoint(startLocation);

            // End at Central Park in New York City.
            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = 40.7669;
            endLocation.Longitude = -073.9790;
            Geopoint endPoint = new Geopoint(endLocation);

            // Get the route between the points.
            MapRouteFinderResult routeResult =
                await MapRouteFinder.GetDrivingRouteAsync(
                startPoint,
                endPoint,
                MapRouteOptimization.Time,
                MapRouteRestrictions.None,
                290
                );

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Display summary info about the route.
                tbTurnByTurn.Inlines.Add(new Run()
                {
                    Text = resourceLoader.GetString("Summary")
                });

                tbTurnByTurn.Inlines.Add(new LineBreak());
                tbTurnByTurn.Inlines.Add(new LineBreak());

                tbTurnByTurn.Inlines.Add(new Run()
                {
                    Text = resourceLoader.GetString("TotalTime") + " = "
                        + routeResult.Route.EstimatedDuration.TotalMinutes.ToString("F1")
                });
                tbTurnByTurn.Inlines.Add(new LineBreak());
                tbTurnByTurn.Inlines.Add(new Run()
                {
                    Text = resourceLoader.GetString("TotalLength") + " = "
                        + (routeResult.Route.LengthInMeters / 1000).ToString("F1")
                });
                tbTurnByTurn.Inlines.Add(new LineBreak());
                tbTurnByTurn.Inlines.Add(new LineBreak());

                // Display the directions.
                tbTurnByTurn.Inlines.Add(new Run()
                {
                    Text = resourceLoader.GetString("Directions")
                });

                tbTurnByTurn.Inlines.Add(new LineBreak());
                tbTurnByTurn.Inlines.Add(new LineBreak());

                // Loop through all the legs and maneuvers.
                foreach (MapRouteLeg leg in routeResult.Route.Legs)
                {
                    foreach (MapRouteManeuver maneuver in leg.Maneuvers)
                    {
                        tbTurnByTurn.Inlines.Add(new Run()
                        {
                            Text = maneuver.InstructionText
                        });

                        tbTurnByTurn.Inlines.Add(new LineBreak());
                        tbTurnByTurn.Inlines.Add(new LineBreak());
                    }

                }

                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Blue;
                viewOfRoute.OutlineColor = Colors.Blue;

                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                MapwithDrivingRoute.Routes.Add(viewOfRoute);
                
                // Fit the MapControl to the route.
                await MapwithDrivingRoute.TrySetViewBoundsAsync(
                    routeResult.Route.BoundingBox,
                    null,
                    Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
            }
            else
            {
                // Tell the user to try again.
                string message = this.resourceLoader.GetString("NoRoute");
                string title = this.resourceLoader.GetString("NoRouteTitle");
                MessageDialog messageDialog = new MessageDialog(message, title);
                await messageDialog.ShowAsync();
            }

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
        /// <summary>
        /// Application Bar Button click event for showing the map and hidding the 
        /// step by step directions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abbMap_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MapwithDrivingRoute.Visibility = Windows.UI.Xaml.Visibility.Visible;
            svTurnByTurn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            abbMap.IsEnabled = false;
            abbDirections.IsEnabled = true;
        }

        /// <summary>
        /// Application Bar Button click event for showing the step by step directions
        /// and hiding the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abbDirections_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MapwithDrivingRoute.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            svTurnByTurn.Visibility = Windows.UI.Xaml.Visibility.Visible;
            abbMap.IsEnabled = true;
            abbDirections.IsEnabled = false;
        }

    }
}