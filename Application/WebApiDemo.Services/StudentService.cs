using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Contracts;
using WebApiDemo.Entities.Model;
using WebApiDemo.Entities.RequestParams;

namespace WebApiDemo.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }
        public void CreateStudent(Student student)
        {
            if (students.Count > 0)
                student.Id = students.Last().Id + 1;
            else
                student.Id = 1;
            students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

        public Student GetStudent(int rollNo)
        {
            return students.SingleOrDefault(student => student.RollNo == rollNo);
        }

        public IEnumerable<Student> GetStudents(StudentRequestParameters studentRequestParameters)
        {
            return students
                .Skip((studentRequestParameters.PageNumber - 1) * studentRequestParameters.PageSize)
                .Take(studentRequestParameters.PageSize);
        }

    }
}
