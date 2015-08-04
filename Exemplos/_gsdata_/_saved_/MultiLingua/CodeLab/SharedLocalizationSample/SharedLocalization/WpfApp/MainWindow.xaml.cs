using System.Windows;
using PortableClassLibrary.Resources;

namespace WpfApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = AppResources.ImFine;
        }
    }
}