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

namespace ComboBox_02
{

    public sealed partial class MainPage : Page
    {
                   ComboBox comboBox1 = new ComboBox();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> fonts = new List<string>();
            fonts.Add("Item 1");
            fonts.Add("Item 2");
            fonts.Add("Item 3");

  //          ComboBox comboBox1 = new ComboBox();
            comboBox1.Name = "cmbBox";
            comboBox1.Width = 200;
            comboBox1.ItemsSource = fonts;
            comboBox1.SelectionChanged += ComboBox_SelectionChanged;
            stackPanel1.Children.Add(comboBox1);
        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            TxtResultado.Text = ((ComboBoxItem)cmbBox.SelectedItem).Content.ToString();
        }

        private void Change_BtnOK(object sender, SelectionChangedEventArgs e)
        {
            //TxtResultado.Text = ((ComboBoxItem)cmbBox.SelectedItem).Content.ToString();
        }
    }
}
