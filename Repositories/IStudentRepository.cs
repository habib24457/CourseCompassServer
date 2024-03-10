using CourseCompass.Models.Domain;

namespace CourseCompass.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetOneStudentById(Guid id);
        Task<Student> CreateStudent(Student student);
    }
}