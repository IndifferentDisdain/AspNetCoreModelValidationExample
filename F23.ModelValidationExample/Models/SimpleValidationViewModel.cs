using F23.ModelValidationExample.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models
{
    public class SimpleValidationViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "SSN")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        public DateTime? DateOfGraduation { get; set; }

        [Required]
        [Display(Name = "Enter an Even Number")]
        public int? EvenNumber { get; set; }
    }
}
