using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RecordCard
    {
        public int RecordCardID { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}
