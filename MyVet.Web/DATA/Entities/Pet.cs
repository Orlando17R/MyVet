using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.DATA.Entities
{
    public class Pet
    {
       
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Race { get; set; }


        [Display(Name = "Nacido")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        //RELACION TABLAS BDD
        public Owner Owner { get; set; }
        public PetType PetType { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<Agenda> Agendas { get; set; }


        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://myvetduarte.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime BornLocal => Born.ToLocalTime();

        //public string ImageFullPath { get; set; }
    }
}