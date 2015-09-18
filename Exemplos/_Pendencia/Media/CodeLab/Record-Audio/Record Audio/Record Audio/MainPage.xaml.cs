using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Record_Audio.Resources;
using System.IO;
using System.Windows.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Record_Audio
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Microphone microphone = Microphone.Default;
        byte[] buffer;
        MemoryStream stream = new MemoryStream();
        SoundEffect sound;    
        public MainPage()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(50);
            dt.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };
            dt.Start();
            microphone.BufferReady += new EventHandler<EventArgs>(microphone_BufferReady);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        void microphone_BufferReady(object sender, EventArgs e)
        {
            microphone.GetData(buffer);
            stream.Write(buffer, 0, buffer.Length);
        }
        private void recordButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Content.ToString()=="Record")
            { 
            microphone.BufferDuration = TimeSpan.FromMilliseconds(1000);
            buffer = new byte[microphone.GetSampleSizeInBytes(microphone.BufferDuration)];
            microphone.Start();
            btn.Content = "Stop";
            }
            else
            {
                if (microphone.State == MicrophoneState.Started)
                {
                    microphone.Stop();
                    btn.Content = "Record";
                }
            }
        }
        
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            sound = new SoundEffect(stream.ToArray(), microphone.SampleRate, AudioChannels.Mono);
            sound.Play();
        }
    }
}