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
            // .include("relationshipDomain") this comes from the domain model of student not from dbContext
            return await dbContext.Courses.Include("Insights").Include("Students").ToListAsync();
        }

        public async Task<Course> GetOneCourseById(Guid id)
        {
            return await dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }
    }

}