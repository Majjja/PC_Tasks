using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        // Methods
        public abstract List<Seminar> GetSeminars();
        public abstract bool IsEligble(int seminarId);
    }
}
