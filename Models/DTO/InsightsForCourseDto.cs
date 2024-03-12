using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCompass.Models.Domain
{
    public class InsightForCourseDto
    {
        public Guid InsightId { get; set; }
        public string StudentInsight { get; set; }
        public Guid CourseId { get; set; }
    }
}