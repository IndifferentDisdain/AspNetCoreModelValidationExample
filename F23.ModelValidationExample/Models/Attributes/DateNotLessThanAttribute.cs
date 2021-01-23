using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace F23.ModelValidationExample.Models.Attributes
{
    /// <summary>
    /// Validation attribute to ensure that a date is not less than
    /// another specified date.
    /// </summary>
    public sealed class DateNotLessThanAttribute : ValidationAttribute
    {
        public DateNotLessThanAttribute(string comparisonProperty)
        {
            ComparisonProperty = comparisonProperty;
        }

        public string ComparisonProperty { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Debug.WriteLine("Entering DateNotLessThanAttribute.IsValid");
            var property = validationContext.ObjectType.GetProperty(ComparisonProperty);
            if (property == null)
                throw new ArgumentException($"Property {ComparisonProperty} not found.");

            if (property.PropertyType != typeof(DateTime?) && property.PropertyType != typeof(DateTime))
                throw new ArgumentException($"Property {ComparisonProperty} is not DateTime? or DateTime.");

            var fromDate = (DateTime?)property.GetValue(validationContext.ObjectInstance);
            var toDate = (DateTime?)value;

            if (fromDate == null || toDate == null)
                return ValidationResult.Success;

            if (toDate < fromDate)
                return new ValidationResult(ErrorMessage ?? $"{ComparisonProperty} is less than the value.");

            return ValidationResult.Success;
        }
    }
}
