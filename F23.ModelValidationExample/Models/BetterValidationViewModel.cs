using F23.ModelValidationExample.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models
{
    /*
     * To do:
     * ReallyRequiredAttribute
     * DateAttribute
     * AttributeUsage?
     * 
     * Model state base controller and view
     * Client side validation lib
     * 
     */
    public class BetterValidationViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required] // ReallyRequired
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [SocialSecurityNumber]
        [StringLength(11)]
        [Display(Name = "SSN")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [Display(Name = "DOB")] // Date
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Graduation Date")] // Date
        [DateNotLessThan(nameof(DateOfBirth))]
        public DateTime? DateOfGraduation { get; set; }

        [Required]
        [EvenNumber(ErrorMessage = "Please enter an even number")]
        [Display(Name = "Enter an Even Number")]
        public int? EvenNumber { get; set; }
    }
}
