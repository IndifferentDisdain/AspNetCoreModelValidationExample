using F23.ModelValidationExample.Models.Attributes;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace F23.ModelValidationExample.Tests.Models.Attributes
{
    public class RegexExpressionsTests
    {
        public static IEnumerable<object[]> EmailAddressesToCheck =>
            new List<object[]>
            {
                new object[]{"", false},
                new object[]{"foo", false},
                new object[]{"foo@", false},
                new object[]{"foo@foo", false},
                new object[]{"foo@foo.", false},
                new object[]{"foo@foo.c", false},
                new object[]{"jshort@feature23.com", true}
            };

        [Theory]
        [MemberData(nameof(EmailAddressesToCheck))]
        public void ValidateEmailAddressExpression(string valueToCheck, bool expectedResult)
        {
            var m = Regex.Match(valueToCheck, RegexExpressions.EmailAddressExpression);
            Assert.Equal(expectedResult, m.Success);
        }

        public static IEnumerable<object[]> SSNsToCheck =>
            new List<object[]>
            {
                new object[]{"1", false},
                new object[]{"12345678", false},
                new object[]{"123456789", true},
                new object[]{"123-45-6789", true},
                new object[]{"12-345-6789", false},
                new object[]{"123-456-789", false}
            };

        [Theory]
        [MemberData(nameof(SSNsToCheck))]
        public void ValidateSSNExpression(string valueToCheck, bool expectedResult)
        {
            var m = Regex.Match(valueToCheck, RegexExpressions.SocialSecurityNumberExpression);
            Assert.Equal(expectedResult, m.Success);
        }
    }
}
