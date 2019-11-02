using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage = "el campo{0}  no puede tener mas de {1} characters.")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "el campo{0}  no puede tener mas de {1} characters.")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "el campo{0}  no puede tener mas de {1} characters.")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "el campo{0}  no puede tener mas de {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50, ErrorMessage = "el campo{0}  no puede tener mas de {1} characters.")]
        public string PhoneNumber { get; set; }
    }
}
