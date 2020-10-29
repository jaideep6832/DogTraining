using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DogTraining.Models;

namespace DogTraining.Training
{
    public class Schedule
    {
        [Key]
        public int SchedID { get; set; }

        /*Linking to Dog Model*/
        [Required, Display(Name = "Dog Name")]
        public int DogID { get; set; }

        [ForeignKey("DogID")]
        public Dog Dog { get; set; }

        /*Linking to Dog Model*/
        [Required, Display(Name = "Trainer")]
        public int TrainerID { get; set; }

        [ForeignKey("TrainerID")]
        public Trainer Trainer { get; set; }


        /*Scheduled date of training class*/
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /*Scheduled time of class*/
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }

        /*Option to add any notes regarding the dog training*/
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Keep notes under 100 characters.")]
        public string Notes { get; set; }
    }
}