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
using Windows.UI.Popups;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Toast_01
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

        private void Everlasting_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(-1, "No timeout toast from Jay!");
        }

        private void WithTimeout_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(10, "10s timeout toast from Jay!");
        }

        private void ZeroTimeout_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(1, "Short timeout toast from Jay!");
        }

        private void ShowToast(int timeoutInSeconds, string text)
        {
            var toastTemplate = ToastTemplateType.ToastImageAndText01;

            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            ////Andreas Hammar 2014-10-08 08:39: note! does not work on windows phone
            //var toastImageAttributes = toastXml.GetElementsByTagName("image");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/jay_transparent.png");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "jay");

            var toast = new ToastNotification(toastXml);

            if (timeoutInSeconds >= 0)
                toast.ExpirationTime = DateTime.Now.AddSeconds(timeoutInSeconds);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
