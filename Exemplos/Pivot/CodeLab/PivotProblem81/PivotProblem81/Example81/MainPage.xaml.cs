using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Example81
{
    [DataContract]
    public class VacationItemViewModel : INotifyPropertyChanged
    {
        public string Header { get; set; }

        private string _name;
        private string _value;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }

        [DataMember]
        public string Value
        {
            get { return _value; }
            set { this.SetProperty(ref _value, value); }
        }

        private ObservableCollection<VacationItemViewModel> vacationItemViewModelItems = new ObservableCollection<VacationItemViewModel>();

        public ObservableCollection<VacationItemViewModel> VacationItemViewModelItems
        {
            get { return vacationItemViewModelItems; }
            set { vacationItemViewModelItems = value; }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;

            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

     ObservableCollection<VacationItemViewModel>  myPivotItems = new ObservableCollection<VacationItemViewModel>() 
     {
            new VacationItemViewModel(){Name="Test1", Value="test1", Header="First Item"},
            new VacationItemViewModel(){Name="Test1", Value="test1", Header="Second Item"}
         };
     foreach (var item in myPivotItems)
     {
         item.VacationItemViewModelItems = new ObservableCollection<VacationItemViewModel>()
             {
                 new VacationItemViewModel(){Name="Test1", Value="test1"},
                 new VacationItemViewModel(){Name="Test1", Value="test1"}
             };
     }
     this.myPivot.DataContext = myPivotItems;
        }
    }
}
