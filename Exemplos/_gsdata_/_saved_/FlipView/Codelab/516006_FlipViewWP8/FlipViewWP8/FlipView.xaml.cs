using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FlipViewWP8
{
    public partial class FlipView : UserControl
    {
        public FlipView()
        {
            InitializeComponent();
            Datasource = new List<object>();
            SelectedIndex = 0;
        }

        private IList Datasource;
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(FlipView), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set
            {
                SetValue(ItemTemplateProperty, value);
                contentPresenter.ContentTemplate = value;
                contentPresenter.Content = SelectedItem;
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
           DependencyProperty.Register("ItemsSource", typeof(IList), typeof(FlipView), new PropertyMetadata(default(IList)));

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                Datasource = value;
                SelectedIndex = SelectedIndex;
            }
        }

        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(FlipView), new PropertyMetadata(default(int)));

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set
            {
                SetValue(SelectedIndexProperty, value);

                rightButton.Visibility = leftButton.Visibility = Visibility.Visible;
                if (SelectedIndex == 0) leftButton.Visibility = Visibility.Collapsed;
                if (SelectedIndex + 1 == Datasource.Count)
                    rightButton.Visibility = Visibility.Collapsed;
                if (Datasource.Count > SelectedIndex + 1)
                    SelectedItem = Datasource[SelectedIndex];
            }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(FlipView), new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                contentPresenter.Content = SelectedItem;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedIndex--;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectedIndex++;
        }
    }
}
