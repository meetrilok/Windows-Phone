using Windows.UI.Xaml;
using PortableClassLibrary.Resources;

namespace WindowsApp
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = AppResources.ImFine;
        }
    }
}