using System;
using System.Collections.Generic;
using System.Text;

namespace Family_Three_Hierarchy_Task_05
{
    public class Parent
    {
        public Parent()
        {
            Children = new List<Child>();
        }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
    }
}
