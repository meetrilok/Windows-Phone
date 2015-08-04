using GalaSoft.MvvmLight;
using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListingContacts.Common;

namespace ListingContacts.ViewModel
{
    public class MainPageViewModel: ViewModelBase
    {
        private ObservableCollection<Contact> _PhoneContacts;
        public ObservableCollection<Contact> PhoneContacts
        {
            get { return _PhoneContacts; }
            set
            {
                _PhoneContacts = value;
                RaisePropertyChanged("PhoneContacts");
            }
        }

        public MainPageViewModel()
        {
            LoadContacts(string.Empty);
        }

        private void LoadContacts(string searchString)
        {
            var contacts = new Contacts();
            contacts.SearchCompleted += ContactsSearchCompleted;
            contacts.SearchAsync(searchString, FilterKind.DisplayName, null);
        }

        void ContactsSearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            PhoneContacts = e.Results.ToObservableCollection();
        }
    }
}
