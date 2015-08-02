using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.IO;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;

namespace ImageMergingwp8
{
    public partial class MergeImages : PhoneApplicationPage
    {
        BitmapImage finalImage = new BitmapImage();
        WriteableBitmap wbFinal;
        public MergeImages()
        {
            InitializeComponent();
        }

      
        private void Mergebtn_click(object sender, RoutedEventArgs e)
        {
            string[] files = new string[] { "Roses-Most-Beautiful-485x728.jpg", "Lovely-Sea-House-485x728.jpg"}; // Image list.
            List<BitmapImage> images = new List<BitmapImage>(); // BitmapImage list.
            int width = 0; // Final width.
            int height = 0; // Final height.

            foreach (string image in files)
            {
                // Create a Bitmap from the file and add it to the list                
                BitmapImage img = new BitmapImage();
                StreamResourceInfo r = System.Windows.Application.GetResourceStream(new Uri(image, UriKind.Relative));
                img.SetSource(r.Stream);

                WriteableBitmap wb = new WriteableBitmap(img);

                // Update the size of the final bitmap
                width = wb.PixelWidth > width ? wb.PixelWidth : width;
                height = wb.PixelHeight > height ? wb.PixelHeight : height;

                images.Add(img);
            }

            // Create a bitmap to hold the combined image 
           
             
            StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri("White.jpg",
                UriKind.Relative));
            finalImage.SetSource(sri.Stream);

            wbFinal = new WriteableBitmap(finalImage);
            using (MemoryStream mem = new MemoryStream())
            {
                int tempWidth = 0;   // Parameter for Translate.X
                int tempHeight = 0;  // Parameter for Translate.Y

                foreach (BitmapImage item in images)
                {
                    Image image = new Image();
                    image.Height = item.PixelHeight;
                    image.Width = item.PixelWidth;
                    image.Source = item;

                    // TranslateTransform                      
                    TranslateTransform tf = new TranslateTransform();
                    tf.X = tempWidth;
                    tf.Y = tempHeight;
                    wbFinal.Render(image, tf);

                    tempHeight += item.PixelHeight;
                }

                wbFinal.Invalidate();
                wbFinal.SaveJpeg(mem, width, height, 0, 100);
                mem.Seek(0, System.IO.SeekOrigin.Begin);

                // Show image.               
                finalmergeimage.Source = wbFinal;
                txtblck.Visibility = Visibility.Visible;
                Savebtn.IsEnabled = true;
            }

            
        }

        private void SaveMergebtn_click(object sender, RoutedEventArgs e)
        {
            // Save image.
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                String strImageName = "demo.jpg";  // File name.

                if (iso.FileExists(strImageName))
                {
                    iso.DeleteFile(strImageName);
                }

                using (IsolatedStorageFileStream isostream = iso.CreateFile(strImageName))
                {
                    // Encode WriteableBitmap object to a JPEG stream.
                    Extensions.SaveJpeg(wbFinal, isostream, wbFinal.PixelWidth, wbFinal.PixelHeight, 0, 85);
                }

                using (IsolatedStorageFileStream fileStream = iso.OpenFile(strImageName, FileMode.OpenOrCreate,
                    FileAccess.Read))
                {
                    MediaLibrary mediaLibrary = new MediaLibrary();
                    Picture pic = mediaLibrary.SavePicture(strImageName, fileStream);
                }
            }
        }
    }
}