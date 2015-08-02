// Copyright (c) Microsoft. All rights reserved.

using System;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace Action_Center_Quickstart
{
    public sealed partial class Scenario1 : Page
    {
        private MainPage rootPage;

        public Scenario1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rootPage = MainPage.Current;
        }

        int toastIndex = 1;
        private void DisplayToast_Click(object sender, RoutedEventArgs e)
        {
            if (MySampleHelper.CanSendToasts())
            {
                ToastNotification toast = MySampleHelper.CreateTextOnlyToast("Scenario 1",String.Format("message {0}", toastIndex));

                toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);
                ToastNotificationManager.CreateToastNotifier().Show(toast); 
                toastIndex++;
                MySampleHelper.ShowSuccessMessage();

            }
        }

    }
}
