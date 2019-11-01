using MyVet.Web.DATA;
using MyVet.Web.DATA.Entities;
using MyVet.Web.Helpers;
using MyVet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.HELPERS
{
    public class ConverterHelper: IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _comboHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper comboHelper)
        {
            _dataContext = dataContext;
            _comboHelper = comboHelper;
        }
        public async Task<Pet> ToPetAsync(PetViewModel model, string path, bool isNew)
        {
            
            var pet = new Pet
            {
                Agendas = model.Agendas,
                Born = model.Born,
                Histories = model.Histories,
                Id=isNew ? 0 : model.Id,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Race = model.Race,
                Remarks = model.Remarks
            };
            
            /*if (model.Id != 0)
            {
                pet.Id = model.Id;
            }*/

            return pet;
        }//final


        public PetViewModel ToPetViewModel(Pet pet)
        {
            return new PetViewModel
            {
                Agendas = pet.Agendas,
                Born = pet.Born,
                Histories = pet.Histories,
                ImageUrl = pet.ImageUrl,
                Name = pet.Name,
                Owner = pet.Owner,
                PetType = pet.PetType,
                Race = pet.Race,
                Remarks = pet.Remarks,
                Id = pet.Id,
                OwnerId = pet.Owner.Id,
                PetTypeId = pet.PetType.Id,
                PetTypes = _comboHelper.GetComboPetTypes()
            };
        }//final

        public async Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew)
        {
            return new History
            {
                Date = model.Date.ToUniversalTime(),
                Description = model.Description,
                Id = isNew ? 0 : model.Id,
                Pet = await _dataContext.Pets.FindAsync(model.PetId),
                Remarks = model.Remarks,
                ServiceType = await _dataContext.ServiceTypes.FindAsync(model.ServiceTypeId)
            };
        }//final

        public HistoryViewModel ToHistoryViewModel(History history)
        {
            return new HistoryViewModel
            {
                Date = history.Date,
                Description = history.Description,
                Id = history.Id,
                PetId = history.Pet.Id,
                Remarks = history.Remarks,
                ServiceTypeId = history.ServiceType.Id,
                ServiceTypes = _comboHelper.GetComboServiceTypes()
            };
        }//final


    }
}
