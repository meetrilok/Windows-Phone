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
using Windows.UI.Popups;

// ====================================================================
// Insercao Obrigatoria
// ====================================================================

using Windows.UI.Popups;

namespace Dialog_02
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
            messageDialog.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(CommandHandlers)));
            messageDialog.Commands.Add(new UICommand("Quit", new UICommandInvokedHandler(CommandHandlers)));
            await messageDialog.ShowAsync();
        }

        public void CommandHandlers(IUICommand commandLabel)
        {
            var Actions = commandLabel.Label;
            switch (Actions)
            {
                //Okay Button.
                case "Ok":
                    //
                    break;
                //Quit Button.
                case "Quit":
                    Application.Current.Exit();
                    break;
                //end.
            }
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            JanelaDialog();
        }

    }
}
