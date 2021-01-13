using System;

namespace F23.ModelValidationExample.Models
{
    public interface ISampleModel
    {
        DateTime? DateOfBirth { get; set; }
        DateTime? DateOfGraduation { get; set; }
        string EmailAddress { get; set; }
        int? EvenNumber { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string SocialSecurityNumber { get; set; }
    }
}