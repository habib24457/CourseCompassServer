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
            // .include("relationshipDomain") this comes from the domain model of student
            return await dbContext.Student.ToListAsync();
        }

        public async Task<Student> GetOneStudentById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await dbContext.Student.FirstOrDefaultAsync(x => x.StudentUserId == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await dbContext.Student.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

    }
}