using System;
using System.Collections.Generic;
using WebApiDemo.Entities.Model;
using WebApiDemo.Entities.RequestParams;

namespace WebApiDemo.Contracts
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents(StudentRequestParameters studentRequestParameters);

        void DeleteStudent(Student student);
        void CreateStudent(Student student);
        Student GetStudent(int rollNo);
    }
}
