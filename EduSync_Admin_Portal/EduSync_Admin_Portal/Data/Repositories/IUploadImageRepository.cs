using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public interface IUploadImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}
