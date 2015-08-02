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
using System.Windows.Media;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Tasks;

namespace ImageMergingwp8
{

    public partial class MergeImageVsText : PhoneApplicationPage
    {
        WriteableBitmap wb;
        public MergeImageVsText()
        {
            InitializeComponent();
        }

        private void Mergebtn_click(object sender, RoutedEventArgs e)
        {
            wb = new WriteableBitmap((BitmapSource)firstimage.Source);
            TextBlock tb = new TextBlock();
            tb.Text = Txt.Text;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = new SolidColorBrush(Colors.Black);
            tb.FontSize = 70;
            tb.FontWeight = FontWeights.Bold;
            wb.Render(tb, new TranslateTransform() { X = 25, Y = 191 });
            wb.Invalidate();
            FinalMergeImage.Source = wb;
            Savebtn.IsEnabled = true;
        }

        private void SaveMergebtn_click(object sender, RoutedEventArgs e)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveJpeg(stream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                stream.Seek(0, SeekOrigin.Begin);
                using (MediaLibrary mediaLibrary = new MediaLibrary())
                    mediaLibrary.SavePicture("Picture.jpg", stream);
            }
            MessageBox.Show("Picture Saved to media library...");
        }

        private void FirstImage_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            photoChooserTask.Show();
        }
        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
               firstimage.Source = new BitmapImage(new Uri(e.OriginalFileName));                
            }
        }
    }
}