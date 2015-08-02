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

namespace ActionCenter_04
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
        int iToastMax = 25;

        private void btnEnviaClick(object sender, RoutedEventArgs e)
        {
            if (SuporteNotificacao.ToastLiberado())
            {
                for (int iAux = 0; iAux < iToastMax; iAux++)
                {

                    ToastNotification tstNotificao = SuporteNotificacao.CriaNotificacaoTexto("ActionCenter-04",
                                                                                              String.Format("Esta é a Mensagem Número {0}",
                                                                                              iToast));
                    tstNotificao.SuppressPopup = true;
                    ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                    iToast++;
                }
            }
        }

        private void btnRemoverClick(object sender, RoutedEventArgs e)
        {
            ToastNotificationManager.History.Clear();
        }
    }
}
