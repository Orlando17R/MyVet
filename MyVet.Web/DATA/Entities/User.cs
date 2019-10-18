using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.DATA.Entities
{
    public class User: IdentityUser
    {

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "el campo {0} no puede ser mayor de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "el campo {0} no puede ser mayor de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "el campo {0} no puede ser mayor de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "el campo {0} no puede ser mayor de {1} caracteres")]
        public string Address { get; set; }

        [Display(Name = "Nombre")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Nombre")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }


}
