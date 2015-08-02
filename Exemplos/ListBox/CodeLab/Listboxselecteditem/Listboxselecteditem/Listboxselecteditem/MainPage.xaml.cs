using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Listboxselecteditem.Resources;

namespace Listboxselecteditem
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            //call the function
            makeasamplelist();
        }

        //Class which acts as a data source for the databound mylistbox
        public class Resultclass
        {
            public string name { get; set; }
            public int  marks { get; set; }
        }

        //Arrays to provide sample data to listbox
        string[] arrayofnames = new string[6] { "Alex", "Fred", "James", "Aman", "Ankur", "Vaibhav" };
        int[] arrayofmarks = new int[6] { 80, 82, 98, 76, 94, 100 };


        //Making a sample list from the data given above
        public void makeasamplelist()
        {
            for (int i = 0; i < 6; i++)
            {
                //Create a new instace of the class
                Resultclass obj = new Resultclass();

                //Add the sample data
                obj.name = arrayofnames[i];
                obj.marks = arrayofmarks[i];

                //Add the the item object into the listbox
                mylistbox.Items.Add(obj);
            }
        }


        //Selection changed event handler for listbox
        private void Selectionchanged_Eventhandler_of_Listbox(object sender, SelectionChangedEventArgs e)
        {
            //Get the data object that represents the current selected item
            Resultclass myobject = (sender as ListBox).SelectedItem as Resultclass;

            //Checks whether that it is not null 
            if (myobject != null)
            {
                //Now you can get the name and marks of selected student from the myobject

                //Display the name and marks of Selected Student in the textblocks given below the listbox.
                Studentnameblock.Text = myobject.name;
                marksblock.Text = myobject.marks.ToString(); ;

            }

        }


        //Event handler for marks button given in the mylisybox
        private void Marks_button_click(object sender, RoutedEventArgs e)
        {
            //Get the data object that represents the current selected item
            Resultclass myobject = (sender as Button).DataContext as Resultclass;

            //Get the selected ListBoxItem container instance of the item whose marks button is pressed
            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            //Checks whether it is not null 
            if (pressedItem != null)
            { 
                //Now you can get the name and marks of selected student from the myobject

                //Display the name and marks of Selected Student in the textblocks given below the listbox.
                Studentnameblock.Text = myobject.name;
                marksblock.Text = myobject.marks.ToString(); ;
            }
        }
    }
}