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


namespace DataTemplate_06
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<dtcMeusDados> MinhaEstrutura = new ObservableCollection<dtcMeusDados>();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            MinhaEstrutura.Add(new dtcMeusDados("/Images/persona1.jpg", "Alexandre Soares", "Engenheiro"));
            MinhaEstrutura.Add(new dtcMeusDados("/Images/persona2.jpg", "Maria Alice", "Antropologa"));
            lstBox.DataContext = MinhaEstrutura;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}