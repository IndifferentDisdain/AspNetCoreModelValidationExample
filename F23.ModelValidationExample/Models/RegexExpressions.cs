namespace F23.ModelValidationExample.Models.Attributes
{
    /// <summary>
    /// Regex expressions collection. Expand and unit test as needed.
    /// </summary>
    public static class RegexExpressions
    {
        public const string SocialSecurityNumberExpression = 
            @"^\d{9}|\d{3}-\d{2}-\d{4}|x{3}-x{2}-\d{4}$";
    }
}
