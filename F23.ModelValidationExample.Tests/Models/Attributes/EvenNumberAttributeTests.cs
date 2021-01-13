using F23.ModelValidationExample.Models.Attributes;
using Xunit;

namespace F23.ModelValidationExample.Tests.Models.Attributes
{
    public class EvenNumberAttributeTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(null, false)]
        public void RunTests(int? value, bool expectedResult)
        {
            Assert.Equal(expectedResult, new EvenNumberAttribute().IsValid(value));
        }
    }
}
