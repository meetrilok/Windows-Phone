using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ListboxBinding.Resources;

namespace ListboxBinding
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //Call any method
            firstmethod();

        }

        //Public class 
        public class Resultclass
        {
            public string name { get; set; }
            public int marks { get; set; }
        }

        //Sample data to be used in the listbox
        string[] studentnames = new string[8] { "Aalap", "Alex", "Aman", "Bharat", "Chetan", "Chitransh", "Vaibhav", "Vivek" };
        int[] studentmarks = new int[8] { 82, 78, 84, 56, 98, 94, 95, 97 };

        public void firstmethod()
        {
            //create a list of Resultclass
            List<Resultclass> mylist = new List<Resultclass>();

            for (int i = 0; i < 8; i++)
            {
                //Create a new object of Result class
                Resultclass obj = new Resultclass();
                
                //add the corresponding data from the sample array
                obj.name = studentnames[i];
                obj.marks = studentmarks[i];

                //add the object into the list created
                mylist.Add(obj);

            }

            //Set the itemsource of the mylistbox created
            mylistbox.ItemsSource = mylist;
        }

        public void secondmethod()
        {
            for (int i = 0; i < 8; i++)
            {
                //Create a new object of Result class
                Resultclass obj = new Resultclass();

                //add the corresponding data from the sample array
                obj.name = studentnames[i];
                obj.marks = studentmarks[i];

                //add the object directly into the list box
                mylistbox.Items.Add(obj);               

            }
        }

    }
}