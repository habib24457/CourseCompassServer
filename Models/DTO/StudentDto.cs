using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseCompass.Models.Domain;

namespace CourseCompass.Models.DTO
{

    public class StudentDto
    {
        [Key]
        public Guid StudentUserId { get; set; } = default;
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }

    }
}