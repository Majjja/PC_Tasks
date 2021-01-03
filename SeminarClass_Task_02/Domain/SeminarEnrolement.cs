using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SeminarEnrolement
    {
        public int Id { get; set; }
        public double MarksReceived { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public IEnumerable<Seminar> Seminars { get; set; }



    }
}
