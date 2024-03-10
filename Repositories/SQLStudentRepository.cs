using CourseCompass.Models;
using CourseCompass.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseCompass.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly CompassDbContext dbContext;
        public SQLStudentRepository(CompassDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllStudent()
        {
            return await dbContext.Student.Include("Insights").Include("Courses").ToListAsync();
        }

        public async Task<Student> GetOneStudentById(Guid id)
        {
            return await dbContext.Student.FirstOrDefaultAsync(x => x.StudentUserId == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await dbContext.Student.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }
    }
}