using System.Threading.Tasks;
using MyVet.Web.DATA.Entities;
using MyVet.Web.Models;

namespace MyVet.Web.HELPERS
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path);
    }
}