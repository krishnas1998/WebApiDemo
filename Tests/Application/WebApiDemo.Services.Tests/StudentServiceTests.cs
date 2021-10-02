using FluentAssertions;
using NUnit.Framework;
using WebApiDemo.Entities.Model;
using WebApiDemo.Test.Infrastructure;

namespace WebApiDemo.Services.Tests
{
    [TestFixture]
    public class StudentServiceTests
    {

        private StudentService _studentService;

        [SetUp]
        public void Setup()
        {
            _studentService = new StudentService();
        }

        [Theory]
        [TestCase(1, "Hno23", "8826013933", "Krishna", 20)]
        [TestCase(1, "Hno23", "8826013933", "Krishna", 20)]
        public void CreateStudentTest1(int id, string address, string contactNo, string name, int rollNo)
        {
            Student student = new Student()
            {
                Id = id,
                Address = address,
                ContactNo = contactNo,
                Name = name,
                RollNo = rollNo
            };
            _studentService.CreateStudent(student);
            
            Assert.AreEqual(student, _studentService.GetStudent(rollNo));
        }

        [Theory]
        [AutoMoqData]
        public void CreateStudentTest(Student student)
        {
           
            _studentService.CreateStudent(student);

            student.Should().Be(_studentService.GetStudent(student.RollNo));
        }
    }
}