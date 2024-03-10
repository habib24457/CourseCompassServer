using System;
namespace CourseCompass.Models.DTO
{
    public class AddStudentsDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
    }
}