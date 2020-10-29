using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogTraining.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }

        /*The first name cannot be more then 20 characters*/
        [Required, Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name cannot be more than 20 characters or less then 2.")]
        public string FirstName { get; set; }

        /*The last name cannot be more then 20 characters*/
        [Required, Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name cannot be more than 20 characters or less then 2.")]
        public string LastName { get; set; }

        /*Combining first & last name to make full name*/
        [Required, Display(Name = "Full Name")]
        [StringLength(41)]
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        /* Defining Phone */
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /*The address cannot be more then 50 characters*/
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Address cannot be more than 50 characters or less then 10.")]
        public string Address { get; set; }
    }
}
