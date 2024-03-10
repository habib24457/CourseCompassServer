using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models.Domain
{
    public class AddCourseDto
    {
        public string CourseName { get; set; }
        public int Attempt { get; set; }
        public bool IsWinterSemester { get; set; }
        public bool IsCompleted { get; set; }
        public int Cgpa { get; set; }
        public string CourseCode { get; set; }
        public bool IsAttempted { get; set; }
        public string ProfessorName { get; set; }
        public string LectureTime { get; set; }
        public string LecturePlace { get; set; }
    }
}