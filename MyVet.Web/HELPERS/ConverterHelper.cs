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
        public async Task<Pet> ToPetAsync(PetViewModel model, string path)
        {
            
            var pet = new Pet
            {
                Agendas = model.Agendas,
                Born = model.Born,
                Histories = model.Histories,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Race = model.Race,
                Remarks = model.Remarks
            };
            
            if (model.Id != 0)
            {
                pet.Id = model.Id;
            }

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

    }
}
