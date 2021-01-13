using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace F23.ModelValidationExample.Models.Attributes
{
    public sealed class SocialSecurityNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
                return false;

            return Regex.Match(stringValue, RegexExpressions.SocialSecurityNumberExpression).Success;
        }
    }
}
