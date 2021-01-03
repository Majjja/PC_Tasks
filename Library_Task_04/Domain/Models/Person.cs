using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
