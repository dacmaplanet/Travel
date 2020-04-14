using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Travel.common.Enums;

namespace Travel.Web.Data.Entities
{
    public class UserEntity : IdentityUser
    {



        /*ATRIBUTES PER USERENTITY  */
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


        [Display(Name = "User Type")]
        public UserType UserType { get; set; }



        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        /*ONE USER [USERENTITY] HAS MUCH TRAVELS  */
        public ICollection<TravelEntity> Travels { get; set; }

        /*ADD BY USER ALL TRAVELS*/
        public decimal Total => Travels == null ? 0 : Travels.Sum(e => e.Total);
    }
}
