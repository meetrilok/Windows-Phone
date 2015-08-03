using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PivotControlDynamicHeader.DataModel
{
    public class DataLoader
    {
        public ObservableCollection<Classroom> ClassRooms { get; set; }


        public DataLoader()
        {
            LoadMockData(8);
        }


        public void LoadMockData(int listSize)
        {
            ClassRooms = new ObservableCollection<Classroom>();

            for (int classRoomCount = 0; classRoomCount < listSize; classRoomCount++)
            {
                var classRoom = new Classroom() { Header = "Header-" + classRoomCount };

                for (int personCount = 0; personCount < listSize; personCount++)
                {
                    classRoom.Persons.Add(new PersonModel() { FirstName = "First Name-" + personCount, LastName = "Last Name-" + personCount, Age = personCount });
                }

                ClassRooms.Add(classRoom);
            }
        }

    }
}
