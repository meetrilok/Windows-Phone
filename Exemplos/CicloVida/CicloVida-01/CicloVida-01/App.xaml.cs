using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// ====================================================================
// Insercao Obrigatoria
// ====================================================================
using System.Diagnostics;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CicloVida_01
{

    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        public App()
        {
            this.InitializeComponent();

            Application.Current.Suspending += new SuspendingEventHandler(Evt_Suspende);
            Application.Current.Resuming += new EventHandler<Object>(Evt_Resume);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Debug.WriteLine("[CICLO] Aplicação Sendo Lançada");

/*
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
*/

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;



                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            
            // Ensure the current window is active
            Window.Current.Activate();

        }

        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        private void Evt_Resume(Object sender, Object e)
        {
            Debug.WriteLine("[CICLO] Aplicação em Resume");
        }

        async void Evt_Suspende ( Object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            Debug.WriteLine("[CICLO] Aplicação em Suspending");
        }

    }
}