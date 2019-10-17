﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.DATA.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de servicio")]
        [MaxLength(50, ErrorMessage = "el campo {0} no puede tener mas de {1} characters.")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public string Name { get; set; }

        //RELACION TABLAS BDD
        public ICollection<History> Histories { get; set; }
    }

}
