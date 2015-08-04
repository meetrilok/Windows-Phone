using System.Windows;
using PortableClassLibrary.Resources;

namespace PhoneApp
{
    public partial class MainPage
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