using F23.ModelValidationExample.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace F23.ModelValidationExample.Models
{
    /// <summary>
    /// Same model as SimpleValidationViewModel, but with some custom validation
    /// attributes and implementation of IValidatableObject
    /// </summary>
    public class BetterValidationViewModel : IValidatableObject
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
        [RegularExpression(RegexExpressions.SocialSecurityNumberExpression, ErrorMessage = "Please enter a valid SSN.")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        [DateNotLessThan(nameof(DateOfBirth), ErrorMessage = "Graduation Date must be greater than DOB.")]
        public DateTime? DateOfGraduation { get; set; }

        [Required]
        [Display(Name = "Enter an Even Number")]
        [EvenNumber(ErrorMessage = "Please enter an even number.")]
        public int? EvenNumber { get; set; }

        /// <summary>
        /// This validation runs after the attributes above. 
        /// Will not run if model validation fails b/c attributes.
        /// Use if you can't use attributes.
        /// Use sparingly.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>List of ValidationResult errors</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Debug.WriteLine("Entering vm.Validate");
            // Add errors to the collection to invalidate the model.
            return new List<ValidationResult>();
        }
    }
}
