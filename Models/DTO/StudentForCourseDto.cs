using System;
namespace CourseCompass.Models.DTO
{
    public class StudentForCourseDto
    {
        public Guid StudentUserId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
    }
}