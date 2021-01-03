using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExamAttendees
    {
        public int ExamAttendeesID { get; set; }
        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
