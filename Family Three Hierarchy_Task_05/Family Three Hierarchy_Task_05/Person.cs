using System;
using System.Collections.Generic;
using System.Text;

namespace Family_Three_Hierarchy_Task_05
{
    public class Person
    {
        public Person()
        {
            Children = new List<Person>();
        }
        public string Name { get; set; }
        //public List<Child> Children { get; set; }
        public List<Person> Children { get; set; }

    }
}
