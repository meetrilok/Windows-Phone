using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using Microsoft.Devices.Sensors;

namespace Example
{
    public partial class MainPage : PhoneApplicationPage
    {
        Motion motion;

        public MainPage()
        {
            InitializeComponent();
            first.Click += first_Click;
            MessageBox.Show("welcome"); //box not showing
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hit");//this doesnt
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            motion = new Motion();
            motion.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            motion.CurrentValueChanged +=
                new EventHandler<SensorReadingEventArgs<MotionReading>>(motion_CurrentValueChanged);

            motion.Start();

        }


        void motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            Dispatcher.BeginInvoke(() => CurrentValueChanged(e.SensorReading));
        }



        private void CurrentValueChanged(MotionReading e)
        {

            txtblck1.Text = "Yaw " + e.Attitude.Yaw.ToString() + " Pitch " + e.Attitude.Pitch + " Roll " + e.Attitude.Roll;
            num.Text = "hit"; //this works
        }
    }
}