using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public double Fees { get; set; }
        public List<Seminar> Seminars { get; set; }

        // Methods
        public void GetDescription(List<Seminar> seminars)
        {
            Console.WriteLine($"Seminars offered by Course with an id : {Id} :");
            foreach (var seminar in seminars)
            {
                Console.WriteLine($"\t{seminar}");
            }
        }
    }
}
