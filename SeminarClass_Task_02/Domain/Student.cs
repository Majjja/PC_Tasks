using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Student : Person
    {
        private string _name;
        private DateTime _birthday;

        public new string Name
        {
            get
            {
                return base.Name;
            }
            private set
            {
                _name = value;
            }
        }

        public new DateTime Birthday
        {
            get
            {
                return base.Birthday;
            }
            private set
            {
                _birthday = value;
            }
        }
        public int SeminarId { get; set; }
        public virtual Seminar Seminar { get; set; }
        public int SeminarEnrolementId { get; set; }
        public virtual SeminarEnrolement SeminarEnrolement { get; set; }

        // Methods
        public override List<Seminar> GetSeminars()
        {
            var seminars = SeminarEnrolement.Seminars.ToList();
            Console.WriteLine($"Enrolled seminars of a Student : ");
            foreach (var seminar in seminars)
            {
                Console.WriteLine($"\t{seminar.Name}");
            }
            return seminars;
        }

        public override bool IsEligble(int seminarId)
        {
            var isEligble = SeminarEnrolement.Seminars.ToList().SingleOrDefault(x => x.Id == seminarId);
            if (isEligble == null)
            {
                return true;
            }
            else return false;
        }
    }
}
