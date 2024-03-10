using CourseCompass.Models.Domain;

namespace CourseCompass.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourse();
        Task<Course> GetOneCourseById(Guid id);
        Task<Course> CreateCourse(Course course);
    }
}