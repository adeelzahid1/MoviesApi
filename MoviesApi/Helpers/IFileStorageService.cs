using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MoviesApi.Helpers
{
    public interface IFileStorageService
    {
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> SaveFile(string containerNmae, IFormFile file);
        Task<string> EditFile(string containerName, IFormFile file, string fileRoute);
    }
}
