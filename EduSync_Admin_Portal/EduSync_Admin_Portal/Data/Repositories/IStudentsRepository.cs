using EduSync_Admin_Portal.DataModel;
using System.Collections.Generic;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public interface IStudentsRepository
    {
        List<Student> GetStudents();
    }
}
