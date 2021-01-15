using F23.ModelValidationExample.Models.Attributes;
using Xunit;

namespace F23.ModelValidationExample.Tests.Models.Attributes
{
    public class SocialSecurityNumberAttributeTests
    {
        [Theory]
        [InlineData("123-00-4567", true)]
        [InlineData("123004567", true)]
        [InlineData("12300455", false)]
        [InlineData("123-00-455", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void RunTests(string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, new SocialSecurityNumberAttribute().IsValid(value));
        }
    }
}
