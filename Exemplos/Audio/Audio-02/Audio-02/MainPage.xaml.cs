﻿using System;
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

namespace Audio_02
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

        private void playSoundButton_Click(object sender, RoutedEventArgs e)
        {
            if ((state == MediaState.Stopped) || (state == MediaState.Paused))
            {
                stopSoundButton.IsEnabled = true;
                pauseSoundButton.IsEnabled = true;
                state = MediaState.Playing;
                myMediaElement.Play();
            }
        }

        private void stopSoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (state == MediaState.Playing)
            {
                state = MediaState.Stopped;
                myMediaElement.Stop();
            }
        }

        private void pauseSoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (state == MediaState.Playing)
            {
                state = MediaState.Paused;
                myMediaElement.Pause();
            }
        }
    }
}
