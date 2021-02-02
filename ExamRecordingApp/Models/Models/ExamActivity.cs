using System;

namespace ExamRecording.Models.Models
{
    public class ExamActivity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int FacultyRoomId { get; set; }
        public FacultyRoom FacultyRoom { get; set; }
        public DateTime DateOfExam { get; set; }
        public int StudentGrade { get; set; }
    }
}
