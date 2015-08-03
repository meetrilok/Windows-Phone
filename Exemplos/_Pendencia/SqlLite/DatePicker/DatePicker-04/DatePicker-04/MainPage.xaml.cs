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

namespace DatePicker_04
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
            arrivalDatePicker.Date = DateTimeOffset.Now.AddMonths(2);
            arrivalDatePicker.MinYear = DateTimeOffset.Now;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyDateIsFuture(arrivalDatePicker.Date) == true)
            {
                Control1Output.Text = string.Format("Thank you. Your arrival is set for {0}.", arrivalDatePicker.Date.ToString("D"));
            }
            else
            {
                Control1Output.Text = "Arrival date must be later than today.";
            }
        }

        private bool VerifyDateIsFuture(DateTimeOffset date)
        {
            if (date > DateTimeOffset.Now)
            {
                return true;
            }
            return false;
        }
    }
}
