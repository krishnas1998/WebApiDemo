using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using WebApiDemo.Entities.Model;
using WebApiDemo.Contracts;
using System;
using WebApiDemo.Infrastructure.Exceptions;
using WebApiDemo.Commands.Properties;

namespace WebApiDemo.Commands.Students.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(
            IMapper mapper,
            IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        public Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student newStudent = _mapper.Map<Student>(request);
            Student oldStudent = _studentService.GetStudent(newStudent.RollNo);
            if (oldStudent != null)
            {
                throw new ResourceAlreadyExistsException(Resources.RollNoAlreadyTakenMessage, Resources.RollNoAlreadyTaken);
            }
            _studentService.CreateStudent(newStudent);

            return Task.FromResult(newStudent); ;
        }

    }
}
