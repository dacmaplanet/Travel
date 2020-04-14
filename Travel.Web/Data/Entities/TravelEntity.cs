using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Travel.Web.Data.Entities
{
    public class TravelEntity
    {
        /*ATRIBUTES PER TRAVELENTITY  */
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}" , ApplyFormatInEditMode = false)]
        public DateTime StartDate{ get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime EndDateLocal => EndDate.ToLocalTime();

        [MaxLength(40, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "City Name")]
        public string City { get; set; }

        
             

        /*ONE TRAVEL [TravelEntity] HAS MUCH EXPENSES*/
        public ICollection<ExpenseEntity> Expenses { get; set; }

        public decimal Total => Expenses == null ? 0 : Expenses.Sum(e => e.Value);

        public UserEntity User { get; set; }



    }
}
