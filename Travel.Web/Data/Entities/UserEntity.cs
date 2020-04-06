using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Web.Data.Entities
{
    public class UserEntity
    {

        public int Id { get; set; }

        /* ATRIBUTOS DE LA ENTIDAD USURIO */
        [Display(Name = "Document")]
        [MaxLength(30, ErrorMessage = "The {0} field can not  have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(20, ErrorMessage = "The {0} field can not  have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "The {0} field can not  have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }



        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        /*UN USUARIO [USERENTITY] TIENE MUCHOS VIAJES  */
        public ICollection<TravelEntity> Travels { get; set; }

        
    }
}
