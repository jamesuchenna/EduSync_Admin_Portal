using AutoMapper;
using EduSync_Admin_Portal.Data.Repositories;
using EduSync_Admin_Portal.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllStudents()
        {
            var student = await _studentRepository.GetStudents();
            return Ok(_mapper.Map<List<Student>>(student));
        }
    }
}
