using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Example81
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<string> commands = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync("sample.docx");
            await Launcher.LaunchFileAsync(file);
        }
    }
}
