using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
    /// <summary>
    /// Attribute to ensure that an integer is an even number
    /// </summary>
    public sealed class EvenNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var intValue = (int?)value;
            if (intValue == null)
                return false;

            return (int)value % 2 == 0;
        }
    }
}
