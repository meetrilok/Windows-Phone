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
using System.Diagnostics;

namespace ComboBox_03
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

        private void Click_BtnOK(object sender, RoutedEventArgs e)
        {
            TxtResultado.Text = ((ComboBoxItem)cmbBox.SelectedItem).Tag.ToString();
        }

        private void ComboBoxDropDownOpen(object sender, object e)
        {
            Debug.WriteLine("[ComboBox-02] Evento Drop Down Open Detectado");
        }

        private void ComboBoxDropDownClose(object sender, object e)
        {
            Debug.WriteLine("[ComboBox-02] Evento Drop Down Close Detectado");
        }
    }
}
