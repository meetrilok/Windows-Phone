using System.Collections.ObjectModel;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


namespace Example81
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<string> commands = new ObservableCollection<string>();

        PointerPoint firstPoint = null;
        ScrollViewer listScrollviewer = null;

        public MainPage()
        {
            this.InitializeComponent();
            myList.ItemsSource = commands;
            for (int i = 0; i < 100; i++) commands.Add("Item " + i.ToString());
            myList.PointerEntered += myList_PointerEntered;
            myList.PointerMoved += myList_PointerMoved;
        }

        private ScrollViewer DisableScrolling(DependencyObject depObj)
        {
            ScrollViewer foundOne = GetScrollViewer(depObj);
            if (foundOne != null) foundOne.VerticalScrollMode = ScrollMode.Disabled;
            return foundOne;
        }

        private void myList_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (listScrollviewer != null)
            {
                PointerPoint secondPoint = e.GetCurrentPoint(myList);
                double verticalDifference = secondPoint.Position.Y - firstPoint.Position.Y;
                listScrollviewer.ChangeView(null, listScrollviewer.VerticalOffset - verticalDifference, null);
            }
            // some other code you need
        }

        private void myList_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            firstPoint = e.GetCurrentPoint(myList);
            if (listScrollviewer == null) listScrollviewer = DisableScrolling(myList);
        }

        public static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }
    }
}
