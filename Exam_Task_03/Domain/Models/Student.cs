using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}
