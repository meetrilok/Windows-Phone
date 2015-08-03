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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ProgressControl_02
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

        private void MostraProgress(object sender, RoutedEventArgs e)
        {
            Circular.IsActive = true;
        }

        private void EscondeProgress(object sender, RoutedEventArgs e)
        {
            Circular.IsActive = false;
        }

        private void VerificaProgress(object sender, RoutedEventArgs e)
        {
            if (Circular.IsActive)
                lblResposta.Text = "Progresso Circular está Ativo";
            else
                lblResposta.Text = "Progresso Circular Não está Ativo";
        }

    }
}
