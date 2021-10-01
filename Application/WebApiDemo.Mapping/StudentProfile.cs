using AutoMapper;
using WebApiDemo.Commands.Students.Create;
using WebApiDemo.Entities.DTO.InputDTO;
using WebApiDemo.Entities.DTO.OutputDTO;
using WebApiDemo.Entities.Model;

namespace WebApiDemo.Mapping
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<Student, StudentOutputDTO>();
            CreateMap<StudentForCreationDTO, CreateStudentCommand>();
            CreateMap<StudentForCreationDTO, Student>();
            CreateMap<StudentForUpdationDTO, Student>();

        }
    }
}
