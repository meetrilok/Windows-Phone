using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ConvertedListViewApp;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LongListSelectorConversion.Resources;

namespace LongListSelectorConversion
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LongListSelector
            SetItemSource();
        }

        private void SetItemSource()
        {
            List<AddressBook> source = new List<AddressBook>();
            source.Add(new AddressBook("Joe", "Smith", "US", "48579347594"));
            source.Add(new AddressBook("Jim", "Johnson", "UK", "3423423423"));
            source.Add(new AddressBook("Mary", "Robert", "India", "9384394793"));
            source.Add(new AddressBook("Patricia", "James", "France", "9384394793"));
            source.Add(new AddressBook("Linda", "Williams", "Italy", "9384394793"));
            source.Add(new AddressBook("David", "Jones", "US", "9384394793"));
            source.Add(new AddressBook("Elizabeth", "Martinez", "US", "9384394793"));
            source.Add(new AddressBook("Richard", "Robinson", "Germany", "9384394793"));
            source.Add(new AddressBook("Charles", "Clark", "US", "9384394793"));
            source.Add(new AddressBook("Joseph", "Rodriguez", "France", "9384394793"));
            source.Add(new AddressBook("Susan", "Lewis", "Italy", "9384394793"));
            source.Add(new AddressBook("Thomas", "Lee", "US", "9384394793"));
            source.Add(new AddressBook("Margaret", "Walker", "US", "9384394793"));
            source.Add(new AddressBook("Christopher", "Hall", "UK", "9384394793"));
            source.Add(new AddressBook("Lisa", "Allen", "US", "9384394793"));
            source.Add(new AddressBook("Daniel", "Young", "US", "9384394793"));
            source.Add(new AddressBook("Paul", "Hernandez", "US", "9384394793"));
            source.Add(new AddressBook("Karen", "King", "US", "9384394793"));
            source.Add(new AddressBook("Ruth", "Wright", "US", "9384394793"));
            source.Add(new AddressBook("Steven", "Lopez", "US", "9384394793"));
            source.Add(new AddressBook("Edward", "Hill", "US", "9384394793"));
            source.Add(new AddressBook("Sharon", "Scott", "US", "9384394793"));
            source.Add(new AddressBook("Brian", "Green", "US", "9384394793"));
            source.Add(new AddressBook("Michelle", "Ramos", "US", "9384394793"));
            source.Add(new AddressBook("Ronald", "Mason", "India", "9384394793"));
            source.Add(new AddressBook("Laura", "Crawford", "US", "9384394793"));
            source.Add(new AddressBook("Anthony", "Burns", "US", "9384394793"));
            source.Add(new AddressBook("Sarah", "Gordon", "India", "9384394793"));
            source.Add(new AddressBook("Kevin", "Hunter", "US", "9384394793"));
            source.Add(new AddressBook("Kimberly", "Tucker", "US", "9384394793"));
            source.Add(new AddressBook("Jason", "Dixon", "US", "9384394793"));
            source.Add(new AddressBook("Deborah", "Mills", "US", "9384394793"));
            source.Add(new AddressBook("Matthew", "Warren", "US", "9384394793"));
            source.Add(new AddressBook("Jessica", "Nichols", "US", "9384394793"));
            source.Add(new AddressBook("Gary", "Knight", "US", "9384394793"));
            source.Add(new AddressBook("Shirley", "Ferguson", "US", "9384394793"));

            List<AlphaKeyGroup<AddressBook>> itemSource = AlphaKeyGroup<AddressBook>.CreateGroups(source,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                s => s.LastName, true);

            AddrBook.ItemsSource = itemSource;
        }
    }
}