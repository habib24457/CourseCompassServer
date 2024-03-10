using AutoMapper;
using CourseCompass.Models.Domain;
using CourseCompass.Models.DTO;

namespace CourseCompass.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<AddStudentsDto, Student>().ReverseMap();
        }
    }
}