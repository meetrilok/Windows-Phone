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

namespace Experiments
{
    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        public class myItems
        {
            public string Title { get; set; }
        }

        public class myList : INotifyPropertyChanged
        {
            public string Name { get; set; }
            private List<myItems> items = new List<myItems>();
            public List<myItems> Items
            {
                get { return items; }
                set
                {
                    items = value;
                    NotifyPropertyChanged("Items");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }


        private ObservableCollection<myList> _Lists = new ObservableCollection<myList>();
        public ObservableCollection<myList> Lists
        {
            get
            {
                return _Lists;
            }
            set
            {
                if (_Lists != value)
                {
                    _Lists = value;
                    NotifyPropertyChanged("Lists");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = this;
            myButton.Click += first_Click;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            while (Lists.Count > 1)
                Lists.RemoveAt(1);

            myList list1 = new myList() { Name = "First" };
            for (int i = 0; i < 100; i++)
                list1.Items.Add(new myItems() { Title = (i + 1).ToString() });

            myList list2 = new myList() { Name = "Second" };
            for (int i = 100; i < 200; i++)
                list2.Items.Add(new myItems() { Title = (i + 1).ToString() });

            myList list3 = new myList() { Name = "Third" };
            for (int i = 200; i < 300; i++)
                list3.Items.Add(new myItems() { Title = (i + 1).ToString() });

            myList list4 = new myList() { Name = "Fourth" };
            for (int i = 300; i < 400; i++)
                list4.Items.Add(new myItems() { Title = (i + 1).ToString() });

            Lists.Add(list1);
            Lists.Add(list2);
            Lists.Add(list3);
            Lists.Add(list4);
            if (Lists.Count > 4)
                Lists.RemoveAt(0);
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}