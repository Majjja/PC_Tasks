using ExamRecording.Models.Enums;
using System.Collections.Generic;

namespace ExamRecording.Models.Models
{
    public class FacultyRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public string Location { get; set; }
        public FacultyRoomType FacultyRoomType { get; set; }
        public ICollection<ExamActivity> ExamActivities { get; set; }
    }
}
