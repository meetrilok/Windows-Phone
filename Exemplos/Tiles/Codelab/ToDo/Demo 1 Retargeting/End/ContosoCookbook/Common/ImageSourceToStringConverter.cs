using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ContosoCookbook.Common
{
    public class ImageSourceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var file = value.ToString();
            if (!file.Contains("/")) return string.Empty;
            var start = file.IndexOf("/") + 1;
            var end = file.IndexOf(".");
            return string.Format("Created Date: {0}", file.Substring(start, (end - start)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
