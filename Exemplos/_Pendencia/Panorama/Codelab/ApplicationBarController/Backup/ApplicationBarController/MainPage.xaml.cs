using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ApplicationBarController
{
    using CAPPLOUD.WP.Controllers;
    using Microsoft.Phone.Shell;
    using System.ComponentModel;

    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        ApplicationBarController appbar;

        ObservableCollection<string> _names = new ObservableCollection<string>();
        public ObservableCollection<string> Names
        {
            get { return this._names; }
            set
            {
                this._names = value;
                NotifyPropertyChanged("Names");
            }
        }

        public MainPage()
        {
            InitializeComponent();
            InitializeControlEvents();
            InitializeControls();
        }

        void InitializeControls()
        {
            // Hook the ApplicationBar in the current page
            this.appbar = new ApplicationBarController(this.ApplicationBar);

            // prepare all Icon Buttons and Menu Items
            this.appbar.AddNewButton("add", "/icons/appbar.add.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("save", "/icons/appbar.save.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("cancel", "/icons/appbar.close.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("delete", "/icons/appbar.delete.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("clear", "/icons/appbar.close.rest.png", true, ApplicationBarIconButton_Click);

            this.appbar.AddNewButton("ff", "/icons/appbar.transport.ff.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("play", "/icons/appbar.transport.play.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("pause", "/icons/appbar.transport.pause.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("rew", "/icons/appbar.transport.rew.rest.png", true, ApplicationBarIconButton_Click);

            this.appbar.AddNewButton("add menu", "/icons/appbar.add.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewButton("clear menus", "/icons/appbar.close.rest.png", true, ApplicationBarIconButton_Click);
            this.appbar.AddNewMenuItem("Message", true, ApplicationBarMenuItem_Click);

            // add initial items in our ListBox
            this.Names.Add("Jayson");
            this.Names.Add("Chevi");
            this.Names.Add("Nikolai");
            this.Names.Add("Irish");
            // Then bind it
            lbNames.ItemsSource = this.Names;
        }

        void InitializeControlEvents()
        {
            txName.GotFocus += delegate
            {
                
            };

            MainPivot.SelectionChanged += new SelectionChangedEventHandler(MainPivot_SelectionChanged);
            lbNames.SelectionChanged += new SelectionChangedEventHandler(lbNames_SelectionChanged);
        }

        void lbNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.appbar.ShowButtons(new string[] { "add", "delete", "clear" });
        }

        int menucount = 0;
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)sender;
            string text = btn.Text.ToLower();

            if (text == "add")
            {
                panelAdd.Visibility = System.Windows.Visibility.Visible;
                lbNames.Visibility = System.Windows.Visibility.Collapsed;

                this.appbar.ShowButtons("save", "cancel");
            }
            else if (text == "save")
            {
                this.Names.Add(txName.Text);
                this.appbar.ShowButtons("add");

                panelAdd.Visibility = System.Windows.Visibility.Collapsed;
                lbNames.Visibility = System.Windows.Visibility.Visible;
            }
            else if (text == "cancel")
            {
                panelAdd.Visibility = System.Windows.Visibility.Collapsed;
                lbNames.Visibility = System.Windows.Visibility.Visible;
                this.appbar.ShowButtons("add");
            }
            else if (text == "delete")
            {
                this.Names.Remove(lbNames.SelectedItem.ToString());
            }
            else if (text == "clear")
            {
                this.Names.Clear();
                this.appbar.ShowButtons("add");
            }
            else if (text == "add menu")
            {
                menucount++;
                string menuname = "Menu Item " + menucount;
                this.appbar.AddNewMenuItem(menuname, true, ApplicationBarMenuItem_Click);
                this.appbar.ShowMenuItem(menuname);
            }
            else if (text == "clear menus")
            {
                this.appbar.RemoveMenuItems();
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationBarMenuItem menu = (ApplicationBarMenuItem)sender;
            string text = menu.Text.ToLower();

            if (text == "message")
            {
                MessageBox.Show("ApplicationBar Controller\r\nCAPPLOUD - Jayson Ragasa");
            }
        }

        void MainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = MainPivot.SelectedIndex;

            switch (i)
            {
                case 0: // dashboard
                    this.appbar.ShowAppBar(false);

                    break;
                case 1: // record
                    this.appbar.ShowAppBar(true);
                    this.appbar.ShowButtons("add");

                    break;
                case 2: // media player
                    this.appbar.ShowAppBar(true);
                    this.appbar.ShowButtons(new string[] { "ff", "pause", "play", "rew" });

                    break;
                case 3: // simle menu
                    this.appbar.ShowAppBar(true);
                    this.appbar.ShowButtons("add menu", "clear menus");
                    this.appbar.ShowMenuItem("Message");

                    break;
            }
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        // Used to notify Silverlight that a property has changed. 
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}