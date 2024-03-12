
using Microsoft.AspNetCore.Mvc;
using CourseCompass.Models;
using CourseCompass.Models.Domain;
using CourseCompass.Models.DTO;
using CourseCompass.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CourseCompass.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CompassDbContext _dbContext;
        private readonly IStudentRepository _studentRepository;
        // private readonly IMapper _mapper;
        public StudentsController(CompassDbContext dbContext, IStudentRepository studentRepository)
        {
            this._dbContext = dbContext;
            this._studentRepository = studentRepository;
            // this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var studentDomain = await _studentRepository.GetAllStudent();
            var studentDtoModel = new List<StudentDto>();
            foreach (var student in studentDomain)
            {
#pragma warning disable CS8601 // Possible null reference assignment.

                studentDtoModel.Add(new StudentDto
                {
                    StudentUserId = student.StudentUserId,
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    Department = student.Department,
                    CourseId = student.CourseId
                });
#pragma warning restore CS8601 // Possible null reference assignment.

            }
            return Ok(studentDtoModel);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOneStudentById([FromRoute] Guid id)
        {
            var studentDomain = await _studentRepository.GetOneStudentById(id);
            if (studentDomain == null)
            {
                return NotFound();
            }
            return Ok(studentDomain);
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentsDto addStudentDto)
        {
            Guid defaultCourseId = Guid.Parse("d56e55eb-d02a-447b-8325-0c98d2b9d49c");
            //map: from dto to domain
            var studentDomainModel = new Student
            {
                StudentId = addStudentDto.StudentId,
                StudentName = addStudentDto.StudentName,
                Department = addStudentDto.Department,
                Password = addStudentDto.Password,
                CourseId = defaultCourseId
            };
            studentDomainModel = await _studentRepository.CreateStudent(studentDomainModel);

            //map: from domain to dto
            var studentDtoModel = new StudentDto
            {
                StudentUserId = studentDomainModel.StudentUserId,
                StudentName = studentDomainModel.StudentName,
                Department = studentDomainModel.Department,
                Password = studentDomainModel.Password
            };

            return CreatedAtAction("CreateStudent", new { id = studentDtoModel.StudentUserId }, studentDtoModel);
        }

        [HttpPost("AddCourseToStudent")]
        public async Task<IActionResult> AddCourseToStudent([FromBody] AddCourseToStudentDto addCourseToStudentDto)
        {
            Guid ConvertedCourseId = addCourseToStudentDto.CourseId;
            //Find the student from DB

            //map from dto to domain
            var studentDomain = new Student
            {

            };

            return Ok();
        }



    }
}