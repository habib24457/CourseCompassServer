using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models.Domain
{
    public class AddCourseToStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Guid CourseId { get; set; }
    }
}