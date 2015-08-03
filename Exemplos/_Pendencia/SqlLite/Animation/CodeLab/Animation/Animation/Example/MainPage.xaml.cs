using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Example.Resources;
using System.Collections.ObjectModel;
using Microsoft.Phone.UserData;
using Microsoft.Phone.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Example
{
    public class Item
    {
        public string Title { get; set; }
        public string SelectedDays { get; set; }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<Item> commands = new ObservableCollection<Item>();

        public MainPage()
        {
            InitializeComponent();

            first.Click += first_Click;
            second.Click += second_Click;
            myList.ItemsSource = commands;

        }

        private FrameworkElement lastSelectedElement = null;

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.lastSelectedElement = sender as FrameworkElement;
        }
        private void first_Click(object sender, RoutedEventArgs e)
        {
            commands.Add(new Item() { Title = "First", SelectedDays = "Monday" });
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj)
where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void second_Click(object sender, RoutedEventArgs e)
        {
            if (this.lastSelectedElement != null)
            {
                // Using the last selected element's datacontext, find the relevant ListBoxItem
                var listBoxItem = myList.ItemContainerGenerator.ContainerFromItem(this.lastSelectedElement.DataContext);

                // Get the actual stackpanel we want to animate
                var element = FindVisualChild<StackPanel>(listBoxItem);

                // Ensure it has the proper transforms
                element.RenderTransform = new CompositeTransform { TranslateX = 0, TranslateY = 0 };

                // Get the storyboard and make sure it is not playing.
                var storyboard = Resources["continuumStoryboard"] as Storyboard;
                storyboard.Stop();

                // Set the stackpanel as the target for each timeline in the storyboard
                foreach (var timeline in storyboard.Children)
                {
                    Storyboard.SetTarget(timeline, element);
                }

                // Play the animation.
                storyboard.Begin();
            }

        }


    }
}