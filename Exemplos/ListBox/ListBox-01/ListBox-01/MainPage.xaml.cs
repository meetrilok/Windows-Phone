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

namespace ListBox_01
{
    public sealed partial class MainPage : Page
    {
        List<String> strSemana = new List<string>() 
        {
            "Sábado",
            "Domingo",
            "Segunda-Feira",
            "Terça-Feira",
            "Quarta-Feira",
            "Quinta-Feira",
            "Sexta-Feira"
        };

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            listBox.ItemsSource = strSemana;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void EventoLista(object sender, SelectionChangedEventArgs e)
        {
            TxtResultado.Text = "Item da Lista: " + strSemana[(listBox.SelectedIndex)];
        }

    }
}
