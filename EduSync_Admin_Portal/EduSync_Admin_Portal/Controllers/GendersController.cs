using AutoMapper;
using EduSync_Admin_Portal.Data.Repositories;
using EduSync_Admin_Portal.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentsRepository studentRepository;
        private readonly IMapper mapper;

        public GendersController(IStudentsRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await studentRepository.GetGendersAsync();

            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderList));
        }
    }
}
