using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DogTraining.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace DogTraining.Training
{
    public class Dog
    {
        [Key]
        public int DogID { get; set; }

        /*The name cannot be more then 20 characters*/
        [Required, Display(Name = "Dog's Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Pet name cannot be more than 20 characters or less then 2.")]
        public string Name { get; set; }

        /*The breed cannot be more then 20 characters*/
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Breed cannot be more than 20 characters or less then 2.")]
        public string Breed { get; set; }

        /*We require the DOB of all dogs*/
        [Required, Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        /*We require the gender of the dog*/
        [Required]
        public DogGender Gender { get; set; }

        /*We need to know if the dog has been neutered*/
        [Required]
        public bool Neutered { get; set; }

        /*The microchip cannot be more then 30 characters*/
        [Required]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Microchip must be between 10 to 30 characters. If your microchip isn't - complain at your local vet.")]
        public string Microchip { get; set; }
    }

    public enum DogGender
    {
        Male, Female
    }
}