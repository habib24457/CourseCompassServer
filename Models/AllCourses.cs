using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models
{
    public class AllCourses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Attempt { get; set; }
        public bool IsWinterSemester { get; set; }
        public bool IsCompleted { get; set; }
        public int Cgpa { get; set; }
        public string CourseCode { get; set; }
        public bool IsAttempted { get; set; }

        public int DetailsId { get; set; }
        public CourseDetails courseDetails { get; set; }

    }
}