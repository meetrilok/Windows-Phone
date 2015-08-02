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

namespace ActionCenter_06
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
                tstNotificao = SuporteNotificacao.CriaNotificacaoTexto("ActionCenter-06", String.Format("MSG Tipo T1 do Grupo G1", iToast));
                tstNotificao.Tag = "Tag";
                tstNotificao.Group = "Grupo";
                tstNotificao.SuppressPopup = true;
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;
            }
        }

        private void btnAlterarClick(object sender, RoutedEventArgs e)
        {
            string updatedMessage = "Mensagem Completamente Nova";
            ToastNotification tstNotificaoAlterada = SuporteNotificacao.CriaNotificacaoTexto("[ActionCenter-06]", updatedMessage);
            tstNotificaoAlterada.SuppressPopup = true;
            tstNotificaoAlterada.Tag = "Tag";
            tstNotificaoAlterada.Group = "Grupo";
            ToastNotificationManager.CreateToastNotifier().Show(tstNotificaoAlterada);
        }

    }
}
