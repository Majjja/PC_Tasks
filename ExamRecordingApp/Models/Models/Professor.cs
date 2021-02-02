using System.Collections.Generic;

namespace ExamRecording.Models.Models
{
    public class Professor : PersonBase
    {
        private readonly ICollection<Course> _courses;
        public ICollection<Course> Courses
        {
            get => _courses;
            set
            {
                if (_courses.Count < 5)
                {
                    _courses.Add((Course)value);
                }
            }
        }
    }
}
