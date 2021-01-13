namespace F23.ModelValidationExample.Models.Attributes
{
    public static class RegexExpressions
    {
        public static readonly string EmailAddressExpression = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";

        public static readonly string SocialSecurityNumberExpression = @"^\d{9}|\d{3}-\d{2}-\d{4}|x{3}-x{2}-\d{4}$";
    }
}
