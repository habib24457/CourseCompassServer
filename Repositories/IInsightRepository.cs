using CourseCompass.Models;
using CourseCompass.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseCompass.Repositories
{
    public interface IInsightRepository
    {
        public Task<List<Insight>> GetAllInsightAsync();
    }
}