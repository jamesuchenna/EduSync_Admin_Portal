using EduSync_Admin_Portal.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
