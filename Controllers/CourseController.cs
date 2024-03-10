
using Microsoft.AspNetCore.Mvc;
using CourseCompass.Models;
using CourseCompass.Models.Domain;
using CourseCompass.Models.DTO;
using CourseCompass.Repositories;

namespace CourseCompass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CompassDbContext _dbContext;
        private readonly ICourseRepository _courseRepository;
        public CourseController(CompassDbContext dbContext, ICourseRepository courseRepository)
        {
            this._dbContext = dbContext;
            this._courseRepository = courseRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var courseDomainModel = await _courseRepository.GetAllCourse();

            //map domain to dto
            var courseDtoModel = new List<CourseDto>();
            foreach (var course in courseDomainModel)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                courseDtoModel.Add(new CourseDto()
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Attempt = course.Attempt,
                    IsWinterSemester = course.IsWinterSemester,
                    IsCompleted = course.IsCompleted,
                    Cgpa = course.Cgpa,
                    CourseCode = course.CourseCode,
                    IsAttempted = course.IsAttempted,
                    ProfessorName = course.ProfessorName,
                    LectureTime = course.LectureTime,
                    LecturePlace = course.LecturePlace,
                    Insights = course.Insights?.Select(insight => new Insight
                    {
                        InsightId = insight.InsightId,
                        StudentInsight = insight.StudentInsight,
                        StudentUserId = insight.StudentUserId,
                        CourseId = insight.CourseId
                    }).ToList(),
                    Students = course.Students?.Select(student => new Student
                    {
                        StudentUserId = student.StudentUserId,
                        StudentId = student.StudentId
                    }).ToList()
                });
#pragma warning restore CS8601 // Possible null reference assignment.
            }


            return Ok(courseDtoModel);

        }

    }
}