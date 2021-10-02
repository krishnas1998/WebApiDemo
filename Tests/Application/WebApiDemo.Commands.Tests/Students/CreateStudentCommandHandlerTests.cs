using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiDemo.Commands.Students.Create;
using WebApiDemo.Contracts;
using WebApiDemo.Entities.Model;
using WebApiDemo.Infrastructure.Exceptions;
using WebApiDemo.Test.Infrastructure;

namespace WebApiDemo.Commands.Tests.Students
{
    public class CreateStudentCommandHandlerTests
    {
        private IRequestHandler<CreateStudentCommand, Student> _handler;
        private Mock<IMapper> _mapperMock;
        private Mock<IStudentService> _studentSericeMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>(MockBehavior.Strict);
            _studentSericeMock = new Mock<IStudentService>(MockBehavior.Strict);
            _handler = new CreateStudentCommandHandler(_mapperMock.Object, _studentSericeMock.Object);
        }

        [Theory]
        [AutoMoqData]
        public async Task Handler_CreatesStudentIfRollNoNotExist(
            CreateStudentCommand request,
            Student student,
            CancellationToken cancellationToken)
        {
            _mapperMock.Setup(x => x.Map<Student>(request)).Returns(student);
            _studentSericeMock.Setup(x => x.GetStudent(student.RollNo)).Returns((Student)null);
            _studentSericeMock.Setup(x => x.CreateStudent(student));
            Student newStudent = await _handler.Handle(request, cancellationToken);

            _mapperMock.VerifyAll();
            newStudent.Should().Be(student);
        }

        [Theory]
        [AutoMoqData]
        public void Handler_CreatesStudentIfRollNoExist(
            CreateStudentCommand request,
            Student student,
            CancellationToken cancellationToken)
        {
            _mapperMock.Setup(x => x.Map<Student>(request)).Returns(student);
            
            _studentSericeMock.Setup(x => x.GetStudent(student.RollNo)).Returns(student);
            _studentSericeMock.Setup(x => x.CreateStudent(student));
            var exception =
                Assert.ThrowsAsync<ResourceAlreadyExistsException>(async () =>
                    await _handler.Handle(request, CancellationToken.None));

            _mapperMock.VerifyAll();
            exception.Message.Should().BeEquivalentTo("'Roll no already taken' already exists.");
        }
    }
}
