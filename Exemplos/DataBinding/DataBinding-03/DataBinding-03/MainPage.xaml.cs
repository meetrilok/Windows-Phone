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

namespace DataBinding_03
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<dtcMeusDados> MinhaEstrutura = new ObservableCollection<dtcMeusDados>();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            MinhaEstrutura.Add(new dtcMeusDados("Alexandre Soares", "Engenheiro"));
            MinhaEstrutura.Add(new dtcMeusDados("Claudia Tallemberg", "Psicologa"));
            MinhaEstrutura.Add(new dtcMeusDados("Dimitri Tallemberg", "Geólogo"));
            cmbBox.DataContext = MinhaEstrutura;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}