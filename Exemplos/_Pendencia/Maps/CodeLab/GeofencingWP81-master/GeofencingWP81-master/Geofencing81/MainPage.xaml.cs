using System;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace Geofencing81
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        private void AddCoordinate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPoint = new BasicGeoposition()
                {
                    Latitude = double.Parse(LatitudeText.Text),
                    Longitude = double.Parse(LongitudeText.Text)
                };
                var geofence = new Geofence(NameText.Text, new Geocircle(newPoint, double.Parse(RadiusText.Text)),
                    MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited,
                    false, TimeSpan.FromSeconds(4));
                GeofenceMonitor.Current.Geofences.Add(geofence);
            }
            catch (Exception ex)
            {
                new MessageDialog("Exception thrown: " + ex.Message).ShowAsync();
            }
        }



        private void StartInForeground_Click(object s, RoutedEventArgs e)
        {
            GeofenceMonitor.Current.GeofenceStateChanged += (sender, args) =>
            {
                var geoReports = GeofenceMonitor.Current.ReadReports();
                foreach (var geofenceStateChangeReport in geoReports)
                {
                    var id = geofenceStateChangeReport.Geofence.Id;
                    var newState = geofenceStateChangeReport.NewState.ToString();
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        new MessageDialog(newState + " : " + id)
                            .ShowAsync());
                }
            };
        }


        private async void StartInBackground_Click(object s, RoutedEventArgs e)
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            var geofenceTaskBuilder = new BackgroundTaskBuilder
            {
                Name = "GeofenceBackgroundTask",
                TaskEntryPoint = "BackgroundTask.GeofenceBackgroundTask"
            };

            var trigger = new LocationTrigger(LocationTriggerType.Geofence);
            geofenceTaskBuilder.SetTrigger(trigger);
            var geofenceTask = geofenceTaskBuilder.Register();
            geofenceTask.Completed += (sender, args) =>
            {
                var geoReports = GeofenceMonitor.Current.ReadReports();
                foreach (var geofenceStateChangeReport in geoReports)
                {
                    var id = geofenceStateChangeReport.Geofence.Id;
                    var newState = geofenceStateChangeReport.NewState.ToString();
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        new MessageDialog(newState + " : " + id)
                        .ShowAsync());
                }
            };
        }


    }
}
