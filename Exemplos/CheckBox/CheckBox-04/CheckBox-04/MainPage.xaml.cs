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

namespace CheckBox_04
 {
     public sealed partial class MainPage : Page
     {
         public MainPage()
         {
             this.InitializeComponent();
             this.NavigationCacheMode = NavigationCacheMode.Required;
             MeuLayout();
         }

         private void MeuLayout()
         {
             CheckBox MeuCheckBox = new CheckBox();

             MeuCheckBox.Width = 70;
             MeuCheckBox.Height = 70;
             MeuCheckBox.Content = "Executa";
             MeuCheckBox.Name = "x:MeuCheckBox";
             MeuCheckBox.Click += btnExecuta_Click;
             MeuStackPanel.Children.Add(MeuCheckBox);
         }

         protected override void OnNavigatedTo(NavigationEventArgs e)
         {
         }

         private void btnExecuta_Click(object sender, RoutedEventArgs e)
         {
             lblResultado.Text = "Ativado Programaticamente";
         }

     }
 }
