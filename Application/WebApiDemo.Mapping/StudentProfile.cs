using AutoMapper;
using System;
using WebApiDemo.Entities.DTO.InputDTO;
using WebApiDemo.Entities.DTO.OutputDTO;
using WebApiDemo.Entities.Model;

namespace WebApiDemo.Mapping
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentOutputDTO>();
            CreateMap<StudentForCreationDTO, Student>();
            CreateMap<StudentForUpdationDTO, Student>();

        }
    }
}
