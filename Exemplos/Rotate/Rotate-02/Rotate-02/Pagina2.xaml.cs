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

using Windows.Graphics.Display;


namespace Rotate_02
{
    public sealed partial class Pagina2 : Page
    {
        public Pagina2()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
