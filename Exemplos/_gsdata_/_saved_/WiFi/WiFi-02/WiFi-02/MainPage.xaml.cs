﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WiFi_02
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

        private void ChecaDisponibilidade(object sender, RoutedEventArgs e)
        {
            var result = NetworkInformation.GetConnectionProfiles();  
            foreach (var connectionProfile in result)  
            {  
                if (connectionProfile.IsWwanConnectionProfile)  
                {  
                    foreach (var networkName in connectionProfile.GetNetworkNames())  
                    {  
                        lblResultado.Text = networkName;//Get mobile operator Name  
                        break;  
                    }  
                }  
            }  
        }  
            
    }
}
