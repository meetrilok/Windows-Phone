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

namespace Dialog_04
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

        private async void JanelaDialog()
        {

            MessageDialog messageDialog = new MessageDialog("Voce Deseja Realmente Sair.");
            messageDialog.Commands.Add(new UICommand ("Sim", new UICommandInvokedHandler(this.ComandoSim)));
            messageDialog.Commands.Add(new UICommand ("Não", new UICommandInvokedHandler(this.ComandoNao))); 
            await messageDialog.ShowAsync();
        }

        private void ComandoSim (IUICommand command)
        {
            // Desenvolva uma Ação
        }
        private void ComandoNao (IUICommand command)
        {
            // Desenvolva uma Ação
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            JanelaDialog();
        }

    }
}
