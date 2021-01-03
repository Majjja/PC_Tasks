using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class Record
    {
        public int RecordID { get; set; }
        public int RecordCardID { get; set; }
        public virtual RecordCard RecordCard { get; set; }
        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
