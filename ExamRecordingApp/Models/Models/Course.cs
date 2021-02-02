using System.Collections.Generic;

namespace ExamRecording.Models.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<ExamActivity> ExamActivities { get; set; }
    }
}
