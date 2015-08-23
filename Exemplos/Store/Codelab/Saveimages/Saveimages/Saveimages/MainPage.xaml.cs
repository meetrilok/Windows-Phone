using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Saveimages.Resources;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.IO;

namespace Saveimages
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }


        //Save the existing image of media library into isolated storage
        private void Save_the_existing_image_click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.PixelWidth = 300;
            task.PixelHeight = 300;
            task.Completed += task_Completed;
            task.ShowCamera = true;
            task.Show();
        }

        private void task_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();
                
                //Best practice is to check whether the file with same name doesn't exits then create a new file
                if (!isoStorage.FileExists("existing.jpg"))
                {
                    IsolatedStorageFileStream fileStream = isoStorage.CreateFile("existing.jpg");
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.DecodePixelHeight = 300;
                    bitmap.DecodePixelWidth = 300;
                    bitmap.SetSource(e.ChosenPhoto);
                    WriteableBitmap wb = new WriteableBitmap(bitmap);
                    wb.SaveJpeg(fileStream, 300, 300, 0, 85);
                    fileStream.Close();
                }
            }
        }

        //Read the file from isolated storage
        private void Read_the_existing_file(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice is to check whether the file with a given name exists in isolated storage or not
            if(isoStorage.FileExists("existing.jpg"))
            {
                using (IsolatedStorageFileStream fileStream = isoStorage.OpenFile("existing.jpg", FileMode.Open, FileAccess.Read))
                {
                    //read the saved image
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(fileStream);

                    //display the image in the imagecontrol
                    imagecontrol.Source = bitmap;
                }
            }
        }


        //Save the captured image to isolated storage
        private void Save_the_captured_image(object sender, RoutedEventArgs e)
        {
            CameraCaptureTask photoCameraCapture = new CameraCaptureTask();
            photoCameraCapture = new CameraCaptureTask();
            photoCameraCapture.Completed += new EventHandler<PhotoResult>(photoCameraCapture_Completed);
            photoCameraCapture.Show(); 
        }

        private void photoCameraCapture_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

                //Best practice is to check whether the file with same name doesn't exits then create a new file
                if (!isoStorage.FileExists("captured.jpg"))
                {
                    IsolatedStorageFileStream fileStream = isoStorage.CreateFile("captured.jpg");
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.DecodePixelHeight = 300;
                    bitmap.DecodePixelWidth = 300;
                    bitmap.SetSource(e.ChosenPhoto);
                    WriteableBitmap wb = new WriteableBitmap(bitmap);
                    wb.SaveJpeg(fileStream, 300, 300, 0, 85);
                    fileStream.Close();
                }
            }
        }

        private void Read_the_captured_image(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice is to check whether the file with a given name exists in isolated storage or not
            if (isoStorage.FileExists("captured.jpg"))
            {
                using (IsolatedStorageFileStream fileStream = isoStorage.OpenFile("captured.jpg", FileMode.Open, FileAccess.Read))
                {
                    //read the saved image
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(fileStream);

                    //display the image in the imagecontrol
                    imagecontrol.Source = bitmap;
                }
            }
        }


        //There is no difference between the read save image code of both the tasks the only differnce is between the filename
       
    }
}