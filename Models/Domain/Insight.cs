using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models.Domain
{
    public class Insight
    {
        public Guid InsightId { get; set; }
        public string StudentInsight { get; set; }
        //Each Insight is associated with each student
        //Each Insight is associated with each/single course
        public Student Student { get; set; } //1:1 relation between insight and student
        public Guid StudentUserId { get; set; } //Foreign key

        public Course Course { get; set; }
        public Guid CourseId { get; set; }

    }
}