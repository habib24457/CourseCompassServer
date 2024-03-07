using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models
{
    public class CourseDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProfessorName { get; set; }
        public string LectureTime { get; set; }
        public string LecturePlace { get; set; }
        public string Insights { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}