using System;
using System.Collections.Generic;

namespace ExamRecording.Models.Models
{
    public class Student : PersonBase
    {
        public DateTime DateOfEnrolling { get; set; }
        public ICollection<ExamActivity> ExamActivities { get; set; }
    }
}
