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

// ====================================================================
// Inclusao Obrigatoria
// ====================================================================

using System.Diagnostics;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace ActionCenter_01
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
            if ( SuporteNotificacao.ToastLiberado())
            {
                ToastNotification tstNotificao = SuporteNotificacao.CriaNotificacaoTexto ( "ActionCenter-01", 
                                                                                            String.Format("Esta é a Mensagem Número {0}", 
                                                                                            iToast));
                tstNotificao.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);
                ToastNotificationManager.CreateToastNotifier().Show(tstNotificao);
                iToast++;
            }
        }
    }
}