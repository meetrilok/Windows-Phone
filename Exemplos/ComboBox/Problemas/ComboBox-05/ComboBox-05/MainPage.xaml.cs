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

namespace ComboBox_05
{
    public sealed partial class MainPage : Page
    {
        ComboBox cmbBox = new ComboBox();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            MeuLayout();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void MeuLayout ()
        {
            cmbBox.Width = 100;
            cmbBox.Height = 5;
            cmbBox.Header = "Escolha";
            cmbBox.Items.Add("Item 1");
            cmbBox.Items.Add("Item 2");
            cmbBox.Items.Add("Item 3");
            cmbBox.SelectionChanged += ComboBoxAlterada;
            MeuStackPanel.Children.Add(cmbBox);
        }

        private void ComboBoxDropDownOpen(object sender, object e)
        {
            Debug.WriteLine("[ComboBox-04] Evento Drop Down Open Detectado");
        }

        private void ComboBoxDropDownClose(object sender, object e)
        {
            Debug.WriteLine("[ComboBox-04] Evento Drop Down Close Detectado");
        }

        private void ComboBoxAlterada(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                txtResultado.Text = ((ComboBoxItem)cmbBox.SelectedItem).Content.ToString();
            }
            catch { }

        }
    }
}
