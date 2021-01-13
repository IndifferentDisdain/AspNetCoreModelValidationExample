using System;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
    public sealed class DateNotLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateNotLessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException($"Property {_comparisonProperty} not found.");

            if (property.PropertyType != typeof(DateTime?) && property.PropertyType != typeof(DateTime))
                throw new ArgumentException($"Property {_comparisonProperty} is not DateTime? or DateTime.");

            var fromDate = (DateTime?)property.GetValue(validationContext.ObjectInstance);
            var toDate = (DateTime?)value;

            if (fromDate == null || toDate == null)
                return ValidationResult.Success;

            if (toDate < fromDate)
                return new ValidationResult(ErrorMessage ?? $"{_comparisonProperty} is less than the value.");

            return ValidationResult.Success;
        }
    }
}
