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

namespace Botao_11
{

    public sealed partial class MainPage : Page
    {
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
            stopSoundButton.IsEnabled = true;
            pauseSoundButton.IsEnabled = true;
        }

        private void stopSoundButton_Click(object sender, RoutedEventArgs e)
        {
            pauseSoundButton.IsEnabled = false;
        }

        private void pauseSoundButton_Click(object sender, RoutedEventArgs e)
        {
            stopSoundButton.IsEnabled = false;
        }
    }
}