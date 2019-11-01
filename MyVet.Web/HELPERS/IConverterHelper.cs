using System.Threading.Tasks;
using MyVet.Web.DATA.Entities;
using MyVet.Web.Models;

namespace MyVet.Web.HELPERS
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path, bool isNew);
        PetViewModel ToPetViewModel(Pet pet);
        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);
        HistoryViewModel ToHistoryViewModel(History history);

    }
}