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

using System.ComponentModel;
using Windows.Phone.UI.Input;
using System.Diagnostics;

namespace HardwareButtons_01
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Debug.WriteLine("[HARDWARE-BUTTON] Botão Back Pressionado");
            e.Handled = true;

/*
            if (some_condition)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
 */
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
