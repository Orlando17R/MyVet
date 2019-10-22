using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyVet.Web.HELPERS
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}