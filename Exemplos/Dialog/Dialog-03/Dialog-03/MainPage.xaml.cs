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

using Windows.UI.Popups;

namespace Dialog_03
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

        private async void JanelaDialogo()
        {
            MessageDialog msgDialog = new MessageDialog("Não existe Rede para Enviar");
            msgDialog.Title = "Alerta";            
            await msgDialog.ShowAsync();
        }
        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            JanelaDialogo();
        }

    }
}
