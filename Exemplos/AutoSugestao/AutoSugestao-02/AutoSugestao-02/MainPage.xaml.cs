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

namespace AutoSugestao_02
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

        private void ExecutaClick (object sender, RoutedEventArgs e)
        {
            lblResultado.Text = txtDigita.Text;
        }

        private void comSugestaoClick(object sender, RoutedEventArgs e)
        {
            txtDigita.IsTextPredictionEnabled = true;
        }

        private void SemSugestaoClick(object sender, RoutedEventArgs e)
        {
            txtDigita.IsTextPredictionEnabled = false;
        }
    }
}