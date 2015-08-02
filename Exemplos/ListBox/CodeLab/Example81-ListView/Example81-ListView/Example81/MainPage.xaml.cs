using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
            myList.ItemsSource = commands;
            for (int i = 0; i < 100; i++)
                commands.Add("Typical item");                
            myList.SelectionChanged+=myList_SelectionChanged;
        }

        private void myList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = myList.SelectedItem;
            ListViewItem listViewItem = this.myList.ContainerFromItem(item) as ListViewItem;
            listViewItem.Foreground = new SolidColorBrush(Colors.GreenYellow);

            //manually scrolling to the selected item
            myList.ScrollIntoView(myList.SelectedItem);
        }
    }
}
