using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseCompass.Models.DTO;

namespace CourseCompass.Models.Domain
{
    public class GetAllCourseCourseDto
    {
        [Key]
        public Guid CourseId { get; set; } = default;
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

        //One course can have many students & Insights 1:N

        public ICollection<InsightForCourseDto> Insights { get; set; } //Each course can be associated with multiple insights

        public ICollection<StudentForCourseDto> Students { get; set; } //Each Course can be associated with multiple students
    }
}