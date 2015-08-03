using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ActionCenterSample
{
    public sealed partial class MainPage : Page
    {
        int ToastCount = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }
        #region Event handlers
        //Sending local toast notifications to action scenter with popup  .
        private void BtnSendToast_Click(object sender, RoutedEventArgs e)
        {
            //Check notificationsettings status from user device
            if (CanSendToasts())
            {
                MakingToastNotification("Toast_with_Popup: ", "Notitification " + ToastCount++, "T" + ToastCount.ToString(), "G1", true);
            }
        }
        //Sending local toast notifications to action scenter without popup  .
        private void BtnSendToastNoPopup_Click(object sender, RoutedEventArgs e)
        {
            //Check notification settings status from user device
            if (CanSendToasts())
            {
                MakingToastNotification("Toast_without_Popup: ", "Notitification " + ToastCount++, "T"+ToastCount.ToString(), "G2", false);
            }
        }
        //Remove notifications from code .
        private void BtnRemoveToast_Click(object sender, RoutedEventArgs e)
        {
            //To Remove all notifications with the given Tag id
            ToastNotificationManager.History.Remove("T1");

            //To Remove all notifications with the given Tag id and Group id
            //ToastNotificationManager.History.RemoveGroup("T1","G1");

            //To Remove all notifications with the given Group id
           // ToastNotificationManager.History.RemoveGroup("G1");

            //To Remove all notifications
            //ToastNotificationManager.History.Clear();

            DisplayMessage("Notifications with Tag 'T1' have been removed.\n Open action center to verify.");
        }
        //Update notifications from code .
        private void BtnUpdateToast_Click(object sender, RoutedEventArgs e)
        {
            MakingToastNotification("Toast_without_Popup: ", "Notitification 1 is updated ","T1", "G1", false);//Update the notifcation which is having Tag 1 ,Group G1
            DisplayMessage("Notifications has been updated with new content.");
        }
        #endregion
        #region HelperMethods
        public bool CanSendToasts()
        {
            bool canSend = true;
            var NotifierStatus = ToastNotificationManager.CreateToastNotifier();
            //Check Notification settings status 
            if (NotifierStatus.Setting != NotificationSetting.Enabled)
            {
                string ReasonMessage = "unknown error";
                switch (NotifierStatus.Setting)
                {
                    case NotificationSetting.DisabledByGroupPolicy:
                        ReasonMessage = "An administrator has disabled all notifications on this computer through group policy. The group policy setting overrides the user's setting.";
                        break;
                    case NotificationSetting.DisabledByManifest:
                        ReasonMessage = "To send a toast from app,developer must be set Toast Capable option to 'Yes' from 'Application Tab' of Package.appxmanifest file.";
                        break;
                    case NotificationSetting.DisabledForApplication:
                        ReasonMessage = "The user has disabled notifications for this app.";
                        break;
                    case NotificationSetting.DisabledForUser:
                        ReasonMessage = "The user or administrator has disabled all notifications for this user on this computer.";
                        break;
                }
                string errroMessage = String.Format("Can't send a toast.\n{0}", ReasonMessage);
                DisplayMessage(errroMessage);
                canSend = false;
            }
            return canSend;
        }
        public void MakingToastNotification(string ToastTitle, string ToastBody, string strTag, string strGroup, bool IsToastPopUpRequired)
        {
            // Using the ToastText02 toast template.This template contains a maximum of two text elements. The first text element is treated as a header text and is always bold.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;

            // Retrieve the content part of the toast so we can change the text.
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            //Find the text component of the content
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(ToastTitle));//Toast notification title
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(ToastBody + " (Tag:" + strTag + ", Group:" + strGroup + ")"));//Toast notification body

            // Set the duration on the toast
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(10);

            //Check Toast popup required to display
            if(!IsToastPopUpRequired)
            {
                toast.SuppressPopup = true;//to send notification directly to action center without displaying a popup on phone.
            }

            //Note: Tag & Group properties are optional,but these are userful for delete/update particular notification from app
            toast.Tag = strTag;
            toast.Group = strGroup;

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        public async void DisplayMessage(string Message)
        {
            MessageDialog messageDialog = new MessageDialog(Message);
            await messageDialog.ShowAsync();
        }
        #endregion
    }
}
