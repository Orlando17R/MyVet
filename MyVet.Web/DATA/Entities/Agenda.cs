using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.DATA.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "el campo {0} es obligatorio.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        //RELACION TABLA BDD
        public Pet Pet { get; set; }
        public Owner Owner { get; set; }



        [Display(Name = "Comentario")] 
        public string Remarks { get; set; }

        [Display(Name = "Esta Disponible?")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

    }
}
