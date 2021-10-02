using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WebApiDemo.Commands.Students.Create;
using WebApiDemo.Entities.Model;
using WebApiDemo.Test.Infrastructure;

namespace WebApiDemo.Mapping.Tests
{
    public class StudentProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<StudentProfile>()));
        }

        [Test]
        public void StudentProfile_Configuration_IsValid()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [AutoMoqData]
        public void Map_CreateFunctionalPrototypeModel_Into_CreateFunctionalPrototypeCommand(
            CreateStudentCommand source)
        {
            var expectedDestination = new CreateStudentCommand()
            {
                Name = source.Name,
                Address = source.Address,
                RollNo = source.RollNo,
                ContactNo = source.ContactNo,

            };
               

            var destination = _mapper.Map<Student>(source);

            destination.Should().BeEquivalentTo(expectedDestination);
        }
    }
}