using EduSync_Admin_Portal.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly EduSyncDbContext _context;

        public StudentsRepository(EduSyncDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var addStudent = await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return addStudent.Entity;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            var deleteStudent = await GetStudentAsync(studentId);

            if (deleteStudent == null)
            {
                return null;
            }
            _context.Remove(deleteStudent);
            _context.SaveChanges();
            return deleteStudent;
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await _context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string imagePath)
        {
            var student = await GetStudentAsync(studentId);

            if(student != null)
            {
                student.Id = studentId;
                student.ProfileImageUrl= imagePath;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existStudent = await GetStudentAsync(studentId);

            if (existStudent == null)
            {
                return null;
            }

            existStudent.FirstName = request.FirstName;
            existStudent.LastName = request.LastName;
            existStudent.DateOfBirth = request.DateOfBirth;
            existStudent.Email = request.Email;
            existStudent.Mobile = request.Mobile;
            existStudent.GenderId = request.GenderId;
            existStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
            existStudent.Address.PostalAddress = request.Address.PostalAddress;

            await _context.SaveChangesAsync();

            return existStudent;
        }
    }
}
