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

using System.Collections.ObjectModel;

namespace DataTemplate_05
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<dtcMeusDados> MinhaEstrutura = new ObservableCollection<dtcMeusDados>();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            MinhaEstrutura.Add(new dtcMeusDados("/Images/laranja.png", "Laranja"));
            MinhaEstrutura.Add(new dtcMeusDados("/Images/maca.png", "Maça"));
            MinhaEstrutura.Add(new dtcMeusDados("/Images/pera.png", "Pera"));
            lstBox.DataContext = MinhaEstrutura;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}