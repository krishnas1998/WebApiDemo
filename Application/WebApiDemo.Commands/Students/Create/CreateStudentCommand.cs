using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using StudentData = WebApiDemo.Entities.Model.Student;

namespace WebApiDemo.Commands.Students.Create
{
    public class CreateStudentCommand : IRequest<StudentData>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string ContactNo { get; set; }

        [Required]
        public int RollNo { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
