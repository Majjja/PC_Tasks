using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Professor : Person
    {
        public string StaffId { get; set; }
        public IEnumerable<Seminar> Seminars { get; set; }

        // Methods
        public override List<Seminar> GetSeminars()
        {
            var seminars = Seminars.ToList();
            Console.WriteLine($"Professor {Name} instructs seminars : ");
            foreach (var seminar in seminars)
            {
                Console.WriteLine($"\t{seminar.Name}");
            }
            return seminars;
        }

        public override bool IsEligble(int seminarId)
        {
            var isEligble = Seminars.ToList().SingleOrDefault(x => x.Id == seminarId);
            if (isEligble == null)
                return false;
            else return true;
        }
    }
}
