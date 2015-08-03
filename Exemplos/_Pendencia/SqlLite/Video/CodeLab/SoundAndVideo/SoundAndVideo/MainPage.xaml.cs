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

namespace SoundAndVideo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private MediaState state = MediaState.Stopped;

        private void playSoundButton_Click(object sender, RoutedEventArgs e)
        {
          myMediaElement.Source = new Uri("ms-appx:///Assets/Duck.wav", UriKind.RelativeOrAbsolute);
          myMediaElement.Play();
        }

        private void playVideoButton_Click(object sender, RoutedEventArgs e)
        {
          //myMediaElement.Source = new Uri("ms-appx:///Assets/coffee.mp4", UriKind.RelativeOrAbsolute);
          //myMediaElement.Play();

          if (state == MediaState.Stopped)
          {
            myMediaElement.Source = new Uri("ms-appx:///Assets/coffee.mp4", UriKind.RelativeOrAbsolute);
            state = MediaState.Playing;
            myMediaElement.Play();
          }
          else if (state == MediaState.Playing)
          {
            state = MediaState.Paused;
            myMediaElement.Pause();
          }
          else if (state == MediaState.Paused)
          {
            state = MediaState.Playing;
            myMediaElement.Play();
          }

        }

        private void myMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
          state = MediaState.Stopped;
        }
    }

    public enum MediaState
    {
      Stopped,
      Playing,
      Paused
    }

}
