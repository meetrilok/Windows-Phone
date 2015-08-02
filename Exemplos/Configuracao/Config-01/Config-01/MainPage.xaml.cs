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

using System;
using System.Diagnostics;

namespace Config_01
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

        private async void ConfiguraDisplay()
        {
            var uri = new Uri("ms-settings-screenrotation:");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao Display Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao Display Falhou");
            }
        }

        private async void ConfiguraBateria()
        {
            var uri = new Uri("ms-settings-power://");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao Bateria Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao Bateria Falhou");
            }
        }

        private async void ConfiguraBluetooth()
        {
            var uri = new Uri("ms-settings-bluetooth:");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao Bluetooth Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao Bluetooth Falhou");
            }
        }


        private async void ConfiguraNotificacao()
        {
            var uri = new Uri("ms-settings-screenrotation:");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao Notificacao Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao Notificacao Falhou");
            }
        }

        private async void ConfiguraWifi ()
        {
            var uri = new Uri("ms-settings-wifi://");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao WiFi Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao WiFi Falhou");
            }
        }

        private async void ConfiguraCelular()
        {
            var uri = new Uri("ms-settings-cellular://");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao Celular Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao Celular Falhou");
            }
        }

        private async void ConfiguraAirplane()
        {
            var uri = new Uri("ms-settings-airplanemode://");
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            bool success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
            if (success)
            {
                Debug.WriteLine("Acesso a Configuracao AirPlane Teve Sucesso");
            }
            else
            {
                Debug.WriteLine("Acesso a Configuracao AirPlane Falhou");
            }
        }

        private void AtivaConfiguracao(object sender, RoutedEventArgs e)
        {
            var TagBotao = (sender as Button).Tag;
            int iTagBotao = Convert.ToInt16(TagBotao);

            switch (iTagBotao)
            {
                case 1:
                    ConfiguraDisplay();
                    break;

                case 2:
                    ConfiguraNotificacao();
                    break;

                case 3:
                    ConfiguraBateria(); 
                    break;

                case 4:
                    ConfiguraBluetooth();
                    break;

                case 5:
                    ConfiguraWifi();
                    break;

                case 6:
                    ConfiguraAirplane();
                    break;

                case 7:
                    ConfiguraCelular();
                    break;

                default:
                    break;
            }
        }

    }
}
