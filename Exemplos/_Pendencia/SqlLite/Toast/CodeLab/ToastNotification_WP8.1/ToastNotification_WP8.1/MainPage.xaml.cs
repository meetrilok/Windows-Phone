using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ToastNotification_WP8._1.Resources;

using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;


namespace ToastNotification_WP8._1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
        }

        private void simpleToast_Click(object sender, RoutedEventArgs e)
        {
            ToastTemplateType toastType = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastType);

            XmlNodeList toastTextElement = toastXml.GetElementsByTagName("text");
            toastTextElement[0].AppendChild(toastXml.CreateTextNode("Hello C# Corner"));
            toastTextElement[1].AppendChild(toastXml.CreateTextNode("I am poping you from a Winmdows Phone App"));

            IXmlNode toastNode= toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration","long");

            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);


        }

        
    }
}