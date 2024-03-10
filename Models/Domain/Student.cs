using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models.Domain
{

    public class Student
    {
        [Key]
        public Guid StudentUserId { get; set; } = default;
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }

        //1:1 One student is associated with only one insight at a time on the insights table
        public Insight Insight { get; set; }
        public Guid InsightId { get; set; }


        //One student is associated with only one course at a time from the courses table
        public Course Course { get; set; }
        public Guid CourseId { get; set; }

    }
}