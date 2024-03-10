using CourseCompass.Models;
using CourseCompass.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseCompass.Repositories
{
    public class SQLInsightRepository : IInsightRepository
    {
        private readonly CompassDbContext dbContext;
        public SQLInsightRepository(CompassDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Insight>> GetAllInsightAsync()
        {
            return await dbContext.Insights.ToListAsync();
        }
    }
}