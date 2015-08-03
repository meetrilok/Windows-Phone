using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Experiments.Resources;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using Windows.Devices.Sensors;

namespace Experiments
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Inclinometer myIncMeter = null;
        private float inclX = 0;
        private float inclY = 0;

        private Accelerometer myAccel = null;
        private double accX = 0;
        private double accY = 0;
        private double accZ = 0;

        public MainPage()
        {
            InitializeComponent();
            this.DataContext = this;
            myIncMeter = Inclinometer.GetDefault();
            myIncMeter.ReportInterval = myIncMeter.MinimumReportInterval;
            myAccel = Accelerometer.GetDefault();
            myAccel.ReportInterval = myIncMeter.MinimumReportInterval;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            InclinometerReading incRead = myIncMeter.GetCurrentReading();
            AccelerometerReading accRead = myAccel.GetCurrentReading();

            accX = accRead.AccelerationX;
            accY = accRead.AccelerationY;
            accZ = accRead.AccelerationZ;

            inclX = incRead.RollDegrees;
            inclY = incRead.PitchDegrees;

            incXTB.Text = "X: " + inclX.ToString("0.00");
            incYTB.Text = "Y: " + inclY.ToString("0.00");

            accXTB.Text = "X: " + accX.ToString("0.00");
            accYTB.Text = "Y: " + accY.ToString("0.00");
            accZTB.Text = "Z: " + accZ.ToString("0.00");

            accincXTB.Text = "X: " + ((Math.Cos(inclY * Math.PI / 180) * Math.Sin(inclX * Math.PI / 180))).ToString("0.00");
            accincYTB.Text = "Y: " + (-Math.Sin(inclY * Math.PI / 180)).ToString("0.00");
            accincZTB.Text = "Z: " + (-(Math.Cos(inclX * Math.PI / 180) * Math.Cos(inclY * Math.PI / 180))).ToString("0.00");
        }
    }
}