using EduSync_Admin_Portal.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetStudents();
    }
}
