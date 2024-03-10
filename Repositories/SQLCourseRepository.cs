using CourseCompass.Models;
using CourseCompass.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseCompass.Repositories
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly CompassDbContext dbContext;
        public SQLCourseRepository(CompassDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await dbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetOneCourseById(Guid id)
        {
            return await dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }
    }

}