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
using Windows.Graphics.Display; // inserir

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Rotate_02
{
    public sealed partial class MainPage : Page
    {
        private SimpleOrientationSensor _simpleorientation;
        public MainPage()
        {
            this.InitializeComponent();

            _simpleorientation = SimpleOrientationSensor.GetDefault();
            // Assign an event handler for the sensor orientation-changed event 
            if (_simpleorientation != null)
            {
                _simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
            }
        }


        private async void OrientationChanged(object sender, SimpleOrientationSensorOrientationChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SimpleOrientation orientation = e.Orientation;
                switch (orientation)
                {
                    case SimpleOrientation.NotRotated:
                        //Portrait Up 
                        txtOrientation.Text = "Not Rotated";
                        break;
                    case SimpleOrientation.Rotated90DegreesCounterclockwise:
                        //LandscapeLeft 
                        txtOrientation.Text = "Rotated 90 Degrees Counterclockwise";
                        break;
                    case SimpleOrientation.Rotated180DegreesCounterclockwise:
                        //PortraitDown 
                        txtOrientation.Text = "Rotated 180 Degrees Counterclockwise";
                        break;
                    case SimpleOrientation.Rotated270DegreesCounterclockwise:
                        //LandscapeRight 
                        txtOrientation.Text = "Rotated 270 Degrees Counterclockwise";
                        break;
                    case SimpleOrientation.Faceup:
                        txtOrientation.Text = "Faceup";
                        break;
                    case SimpleOrientation.Facedown:
                        txtOrientation.Text = "Facedown";
                        break;
                    default:
                        txtOrientation.Text = "Unknown orientation";
                        break;
                }
            });
        }

        private void OrientationBtn_Click(object sender, RoutedEventArgs e)
        {
            /***To support both***/
            // DisplayInformation.AutoRotationPreferences = DisplayOrientations.None; 

            /***To support only landscape***/
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;

            /***To support only potrait 90 degress clock wise***/
            //  DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait; 

            /***To flip 180 degrees from potrait mode***/
            // DisplayInformation.AutoRotationPreferences = DisplayOrientations.PortraitFlipped; 

            /***To flip 180 degrees from landscape mode***/
            // DisplayInformation.AutoRotationPreferences = DisplayOrientations.LandscapeFlipped; 
        }

        private void Current_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            string CurrentViewState = ApplicationView.GetForCurrentView().Orientation.ToString();
            StatusTxtBlck.Text = "Curren Page Orientation is: " + CurrentViewState;
            if (CurrentViewState == "Portrait")
            {
                //To Do UI for potrait 
            }

            if (CurrentViewState == "Landscape")
            {
                //To Do UI for landscape   
            }
        }

    }
}