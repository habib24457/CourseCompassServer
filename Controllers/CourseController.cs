
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
            var courseDtoModel = new List<GetAllCourseCourseDto>();
            foreach (var course in courseDomainModel)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                courseDtoModel.Add(new GetAllCourseCourseDto()
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
                    Insights = course.Insights?.Select(insight => new InsightForCourseDto
                    {
                        InsightId = insight.InsightId,
                        StudentInsight = insight.StudentInsight,
                        StudentUserId = insight.StudentUserId,
                        CourseId = insight.CourseId
                    }).ToList(),
                    Students = course.Students?.Select(student => new StudentForCourseDto
                    {
                        StudentUserId = student.StudentUserId,
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        Department = student.Department,
                    }).ToList()
                });
#pragma warning restore CS8601 // Possible null reference assignment.
            }


            return Ok(courseDtoModel);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] AddCourseDto addCourseDto)
        {
            /*From Dto to domain*/
            var courseDomainModel = new Course
            {
                CourseName = addCourseDto.CourseName,
                Attempt = addCourseDto.Attempt,
                IsWinterSemester = addCourseDto.IsWinterSemester,
                IsCompleted = addCourseDto.IsCompleted,
                Cgpa = addCourseDto.Cgpa,
                CourseCode = addCourseDto.CourseCode,
                IsAttempted = addCourseDto.IsAttempted,
                ProfessorName = addCourseDto.ProfessorName,
                LecturePlace = addCourseDto.LectureTime,
                LectureTime = addCourseDto.LectureTime
            };

            courseDomainModel = await _courseRepository.CreateCourseAsync(courseDomainModel);

            /*Map: Domain back to dto*/
            var courseDto = new CourseDto
            {
                CourseId = courseDomainModel.CourseId,
                CourseName = addCourseDto.CourseName,
                Attempt = addCourseDto.Attempt,
                IsWinterSemester = addCourseDto.IsWinterSemester,
                IsCompleted = addCourseDto.IsCompleted,
                Cgpa = addCourseDto.Cgpa,
                CourseCode = addCourseDto.CourseCode,
                IsAttempted = addCourseDto.IsAttempted,
                ProfessorName = addCourseDto.ProfessorName,
                LecturePlace = addCourseDto.LectureTime,
                LectureTime = addCourseDto.LectureTime
            };

            return CreatedAtAction("CreateCourse", new { id = courseDto.CourseId }, courseDto);
        }

    }
}