using AutoMapper;
using EduSync_Admin_Portal.Data.Repositories;
using EduSync_Admin_Portal.DataModel;
using EduSync_Admin_Portal.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Student = EduSync_Admin_Portal.DataModel.Student;

namespace EduSync_Admin_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var student = await _studentRepository.GetStudentsAsync();
            return Ok(_mapper.Map<List<Student>>(student));
        }

        [HttpGet("{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await _studentRepository.GetStudentAsync(studentId);

            if(student== null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Student>(student));
        }

        [HttpPost("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if(await _studentRepository.Exists(studentId))
            {
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<Student>(request));

                if(updatedStudent !=null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();
        }
    }
}
