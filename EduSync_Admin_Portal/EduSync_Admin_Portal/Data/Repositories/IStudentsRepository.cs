using EduSync_Admin_Portal.DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student student);
        Task<bool> UpdateProfileImage(Guid studentId, string imagePath);
    }
}
