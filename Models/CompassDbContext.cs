
using Microsoft.EntityFrameworkCore;
using CourseCompass.Models.Domain;

namespace CourseCompass.Models
{
    public class CompassDbContext : DbContext
    {
        public CompassDbContext(DbContextOptions<CompassDbContext> options) : base(options) { }


        //Creating the tables
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Insight> Insights { get; set; }


        /*Making the relationships between the table
        *Students have many courses and many insights.
        *One course has many students and many insights.
        *One insight has one student and one course.
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .HasPrincipalKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Insight>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Insights)
                .HasForeignKey(i => i.CourseId)
                .HasPrincipalKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Course>(entity =>
            // {
            //     entity.HasKey(c => c.CourseId);                //Primary Key 
            //     // Configure 1:N relationship between Course and Student
            //     //one course has many students. Course has One to Many relation with student model
            //     entity.HasMany(c => c.Students)
            //         .WithOne(s => s.Course)
            //         .HasForeignKey(s => s.CourseId)
            //         .OnDelete(DeleteBehavior.NoAction);
            //     //one course has many insights. Course has One to Many relation with Insight model 
            //     // Configure 1:N relationship between Course and Insight
            //     entity.HasMany(c => c.Insights)
            //         .WithOne(i => i.Course)
            //         .HasForeignKey(i => i.CourseId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // modelBuilder.Entity<Student>(entity =>
            // {
            //     entity.HasOne(s => s.Course)
            //             .WithMany(c => c.Students)
            //             .HasForeignKey(c => c.CourseId)
            //             .OnDelete(DeleteBehavior.NoAction);
            // });

            // modelBuilder.Entity<Insight>(entity =>
            //     {
            //         entity.HasKey(i => i.InsightId); //Primary Key
            //         entity.HasOne(i => i.Course)
            //          .WithMany(c => c.Insights)
            //         .HasForeignKey(i => i.CourseId)
            //         .OnDelete(DeleteBehavior.NoAction);
            //     });
        }
    }
}