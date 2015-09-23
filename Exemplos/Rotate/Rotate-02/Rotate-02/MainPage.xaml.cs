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
using Windows.Graphics.Display;
using Windows.UI.Popups;

namespace Rotate_02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MeuBotao.Click += PrimeiroClick;
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.LandscapeFlipped;
        }

        private void PrimeiroClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pagina1));
        }
    }
}
