using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MessageDialogSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Message1ButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Some sample text.", "Dialog Title");
            await dialog.ShowAsync();
        }

        private async void Message2ButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Some sample text.");

            dialog.Commands.Add(new UICommand("Retry", new UICommandInvokedHandler(CommandHandler)));
            dialog.Commands.Add(new UICommand("Ignore", new UICommandInvokedHandler(CommandHandler)));
            dialog.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(CommandHandler)));

            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 2;

            await dialog.ShowAsync();
        }

        private void Message3ButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CommandHandler(IUICommand command)
        {
            var commandLabel = command.Label;
            switch (commandLabel)
            {
                case "Retry":
                    //Do Something
                    break;
                case "Ignore":
                    //Do Something
                    break;
                case "Cancel":
                    //Do Something
                    break;
            }
        }
    }
}
