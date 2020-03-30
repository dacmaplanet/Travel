using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Data.Entities
{
    public class TravelEntity
    {
        public int Id { get; set; }

        [StringLength(12, MinimumLength = 4, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Reservation { get; set; }

    }
}
