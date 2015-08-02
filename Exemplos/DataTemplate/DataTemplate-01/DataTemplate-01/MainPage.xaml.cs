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

namespace DataTemplate_01
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

        private void ListBoxAlterada (object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbiBoxItem = ((sender as ListBox).SelectedItem as ListBoxItem);
            SelectDataTemplate(lbiBoxItem.Content);
        }

        private void SelectDataTemplate(object objValor)
        {
            string strNumero = objValor as string;

            if (strNumero != null)
            {
                int num;

                try
                {
                    num = Convert.ToInt32(strNumero);
                }
                catch
                {
                    return;
                }

                DataTemplate template;
                if (num % 2 != 0)
                {
                    template = StackPanelRaiz.Resources["NumeroImpar"] as DataTemplate;
                }
                else
                {
                    template = StackPanelRaiz.Resources["NumeroPar"] as DataTemplate;
                }

                MostraItemSelecionado.Child = template.LoadContent() as UIElement;
                TextBlock txtResultado = FindVisualChild<TextBlock>(MostraItemSelecionado);
                txtResultado.Text = strNumero;
            }
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
