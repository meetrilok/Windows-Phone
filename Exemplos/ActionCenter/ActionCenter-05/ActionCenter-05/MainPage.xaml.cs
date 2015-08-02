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
// Inclusao Obrigatoria
// ====================================================================

using System.Diagnostics;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace ActionCenter_05
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


        int iToast = 1;
        private void btnEnviaClick(object sender, RoutedEventArgs e)
        {

            ToastNotification tstNotificao; 

            if (SuporteNotificacao.ToastLiberado())
            {
                tstNotificao = SuporteNotificacao.CriaNotificacaoTexto( "ActionCenter-05", String.Format("MSG Tipo T1 do Grupo G1",iToast));
                tstNotificao.Tag = "T1";
                tstNotificao.Group = "G1";
                tstNotificao.SuppressPopup = true;
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;

                tstNotificao = SuporteNotificacao.CriaNotificacaoTexto("ActionCenter-05", String.Format("MSG Tipo T2 do Grupo G1", iToast));
                tstNotificao.Tag = "T2";
                tstNotificao.Group = "G1";
                tstNotificao.SuppressPopup = true;
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;

                tstNotificao = SuporteNotificacao.CriaNotificacaoTexto("ActionCenter-05", String.Format("MSG Tipo T1 do Grupo G2", iToast));
                tstNotificao.Tag = "T1";
                tstNotificao.Group = "G2";
                tstNotificao.SuppressPopup = true;
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;

                tstNotificao = SuporteNotificacao.CriaNotificacaoTexto("ActionCenter-05", String.Format("MSG Tipo T2 do Grupo G2", iToast));
                tstNotificao.Tag = "T2";
                tstNotificao.Group = "G2";
                tstNotificao.SuppressPopup = true;
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;

            }
        }

        private void btnRemoverClick(object sender, RoutedEventArgs e)
        {

            ToastNotificationManager.History.Clear();
        }

        private void btnRemoverG1Click(object sender, RoutedEventArgs e)
        {
            ToastNotificationManager.History.RemoveGroup("G1");
        }

        private void btnRemoverG2Click(object sender, RoutedEventArgs e)
        {
            ToastNotificationManager.History.RemoveGroup("G2");
        }

        private void btnRemoverT1Click(object sender, RoutedEventArgs e)
        {
            ToastNotificationManager.History.Remove("T1", "G1");
            ToastNotificationManager.History.Remove("T1", "G2");
        }
    }
}