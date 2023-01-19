using AutoMapper;
using EduSync_Admin_Portal.Data.Repositories;
using EduSync_Admin_Portal.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImageRepository _uploadImage;

        public StudentsController(IStudentsRepository studentRepository, IMapper mapper, IUploadImageRepository uploadImage)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _uploadImage = uploadImage;
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

            if (student == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Student>(student));
        }

        [HttpPut("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<DataModel.Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();
        }

        [HttpDelete("{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var deleteStudent = await _studentRepository.DeleteStudent(studentId);
                return Ok(_mapper.Map<Student>(deleteStudent));
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            var addStudent = await _studentRepository.AddStudent(_mapper.Map<DataModel.Student>(request));
            
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = addStudent.Id },
                _mapper.Map<Student>(addStudent));
        }

        [HttpPost("{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                var fileImagePath = await _uploadImage.Upload(profileImage, fileName);

                if (await _studentRepository.UpdateProfileImage(studentId, fileImagePath))
                {
                    return Ok(fileImagePath);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
        }
    }
}
