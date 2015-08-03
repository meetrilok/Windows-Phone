using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PivotControlDynamicHeader.DataModel
{
    public class Classroom
    {

        public Classroom()
        {
            Persons = new List<PersonModel>();
        }

        public string Header { get; set; }

        public List<PersonModel> Persons { get; set; }

    }
}
