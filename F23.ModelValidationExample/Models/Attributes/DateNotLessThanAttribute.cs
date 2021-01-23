using System;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
    public sealed class DateNotLessThanAttribute : ValidationAttribute
    {
        public DateNotLessThanAttribute(string comparisonProperty)
        {
            ComparisonProperty = comparisonProperty;
        }

        public string ComparisonProperty { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
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
