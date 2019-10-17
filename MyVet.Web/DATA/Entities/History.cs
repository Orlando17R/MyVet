using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.DATA.Entities
{
    public class History
    {

        public int Id { get; set; }
        //RELACION TABLAS BDD
        public ServiceType ServiceType { get; set; }
        public Pet Pet { get; set; }
        public ICollection<History> Histories { get; set; }



        [Display(Name = "Description")]
        [MaxLength(100, ErrorMessage = "el campo {0} no puede ser mayor de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

    }
}
