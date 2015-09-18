﻿using System;
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
    public class StringImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var file = value.ToString();

            var storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists(file))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.CreateOptions = BitmapCreateOptions.None;
                var stream = storage.OpenFile(file, FileMode.Open);
                bitmap.SetSource(stream);
                stream.Close();

                return bitmap;
            }
            else
            {
                var stream = storage.CreateFile(file);
                
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
