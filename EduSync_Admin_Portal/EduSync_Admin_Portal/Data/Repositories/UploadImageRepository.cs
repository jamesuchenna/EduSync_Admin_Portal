using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace EduSync_Admin_Portal.Data.Repositories
{
    public class UploadImageRepository : IUploadImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources/Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return GetServerRelativePath(fileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources/Images", fileName);
        }
    }
}
