using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
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
