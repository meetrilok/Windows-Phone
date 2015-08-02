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

// ====================================================================
// Insercao Obrigatoria
// ====================================================================

using Windows.UI.Notifications;

namespace NotifyUser_01
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

        public void NotifyUser(string strMessage, NotifyType type)
        {
            if (StatusBlock != null)
            {
                switch (type)
                {
                    case    NotifyType.StatusMessage:
                            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            break;

                    case    NotifyType.ErrorMessage:
                            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                            break;
                }
                StatusBlock.Text = strMessage;
                if (strMessage != String.Empty)
                {
                    StatusBorder.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    StatusBorder.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
        }

        private void btnErroClick(object sender, RoutedEventArgs e)
        {
            NotifyUser("Essa é uma Mensagem de Erro", NotifyType.ErrorMessage);
        }

        private void btnAlertaClick(object sender, RoutedEventArgs e)
        {
            NotifyUser("Essa é uma Mensagem de Status", NotifyType.StatusMessage);
        }

        private void btnLimpaClick(object sender, RoutedEventArgs e)
        {
            NotifyUser( "", NotifyType.StatusMessage);
        }
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
}
