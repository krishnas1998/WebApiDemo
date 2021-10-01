using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Commands.Students.Create;
using WebApiDemo.Contracts;
using WebApiDemo.Entities.DTO.InputDTO;
using WebApiDemo.Entities.DTO.OutputDTO;
using WebApiDemo.Entities.Model;
using WebApiDemo.Entities.RequestParams;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public StudentsController(
            IMediator mediator,
            IStudentService studentService,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _studentService = studentService;
            _mapper = mapper;

        }
        // GET: api/<StudentController>
        // Get all students bases on query parameters - PageSize and PageN
        // <Status type>
        // status: 200 - Ok
        // status: 500 - Internal server error
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] StudentRequestParameters requestParameters)
        {
            IEnumerable<Student> students = _studentService.GetStudents(requestParameters);
            IEnumerable<StudentOutputDTO> studentsOutput = _mapper.Map<IEnumerable<StudentOutputDTO>>(students);
            return Ok(studentsOutput);
        }

        // GET api/<StudentController>/5
        [HttpGet("{rollNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int rollNo)
        {
            Student student = _studentService.GetStudent(rollNo);
            StudentOutputDTO studentOutput = _mapper.Map<StudentOutputDTO>(student);
            return Ok(studentOutput);
        }

        // POST api/<StudentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand studentDTO)
        {
            Student newStudent = await _mediator.Send(studentDTO);
            
           
            return CreatedAtAction(nameof(Post), newStudent);
        }

        //// PUT api/<StudentController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] StudentForUpdationDTO value)
        //{
        //}

        // DELETE api/<StudentController>/5
        [HttpDelete("{rollNo}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int rollNo)
        {
            Student studentToDelete = _studentService.GetStudent(rollNo);
            if (studentToDelete == null)
            {
                ModelState.AddModelError("Roll No", "Invalid roll no");
                return NotFound(ModelState);
            }
            _studentService.DeleteStudent(studentToDelete);
            return NoContent();
        }
    }
}
