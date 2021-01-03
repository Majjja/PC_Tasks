using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<RecordCard> RecordCards { get; set; }

    }
}
