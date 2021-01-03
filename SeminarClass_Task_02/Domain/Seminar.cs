using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Seminar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> WaitingList { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public IEnumerable<SeminarEnrolement> Students { get; set; }
        
        
        // Methods
        public bool AddStudent(SeminarEnrolement student)
        {
            var exists = Students.SingleOrDefault(x => x.Id == student.Id);
            if (exists == null)
            {
                Students.ToList().Add(student);
                return true;
            }
            else return false;
        }
        public bool RemoveStudent(SeminarEnrolement student)
        {
            var exists = Students.SingleOrDefault(x => x.Id == student.Id);
            if (exists == null)
            {
                return false;
            }
            else
            {
                Students.ToList().Remove(student);
                return true;
            }
        }
    }
}
