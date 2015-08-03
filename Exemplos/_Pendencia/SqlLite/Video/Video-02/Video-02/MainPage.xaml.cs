using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Video_02
{
    public sealed partial class MainPage : Page
    {
        public enum MediaState
        {
            Stopped,
            Playing,
            Paused
        }
        private MediaState state = MediaState.Stopped;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void playVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if ((state == MediaState.Stopped) || (state == MediaState.Paused))
            {
                myMediaElement.Source = new Uri("ms-appx:///Assets/video.mp4", UriKind.RelativeOrAbsolute);
                state = MediaState.Playing;
                myMediaElement.Play();
            }
        }

        private void stopVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if (state == MediaState.Playing)
            {
                state = MediaState.Stopped;
                myMediaElement.Stop();
            }
        }

        private void pauseVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if (state == MediaState.Playing)
            {
                state = MediaState.Paused;
                myMediaElement.Pause();
            }
        }
    }
}
