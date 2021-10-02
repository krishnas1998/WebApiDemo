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
            CreateMap<CreateStudentCommand, Student>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Student, StudentOutputDTO>();

            CreateMap<StudentForCreationDTO, CreateStudentCommand>();

            CreateMap<StudentForCreationDTO, Student>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<StudentForUpdationDTO, Student>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.RollNo, opt => opt.Ignore());

        }
    }
}
