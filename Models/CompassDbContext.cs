
using Microsoft.EntityFrameworkCore;

namespace CourseCompass.Models
{
    public class CompassDbContext : DbContext
    {
        public CompassDbContext(DbContextOptions<CompassDbContext> options) : base(options)
        {

        }
    }
}