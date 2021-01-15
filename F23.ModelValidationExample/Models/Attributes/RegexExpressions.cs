namespace F23.ModelValidationExample.Models.Attributes
{
    public static class RegexExpressions
    {
        public static readonly string SocialSecurityNumberExpression = @"^\d{9}|\d{3}-\d{2}-\d{4}|x{3}-x{2}-\d{4}$";
    }
}
