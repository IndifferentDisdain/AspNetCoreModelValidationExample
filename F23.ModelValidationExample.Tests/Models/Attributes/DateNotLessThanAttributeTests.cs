using F23.ModelValidationExample.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace F23.ModelValidationExample.Tests.Models.Attributes
{
    public class DateNotLessThanAttributeTests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {new TestModel(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)), true},
                new object[] {new TestModel(null, new DateTime(2020, 12, 31)), true},
                new object[] {new TestModel(new DateTime(2020, 12, 31), null), true},
                new object[] {new TestModel(null, null), true},
                new object[] {new TestModel(new DateTime(2020, 12, 31), new DateTime(2020, 01, 01)), false},
                new object[] {new TestModelNotNullable(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)), true},
                new object[] {new TestModelNotNullable(new DateTime(2021, 01, 01), new DateTime(2020, 12, 31)), false}
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Validation_Tests_NoExceptions(object model, bool expectedResult)
        {
            Assert.Equal(expectedResult, TryValidateObject(model));
        }

        [Fact]
        public void WrongPropertyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => TryValidateObject(new WrongPropertyName()));
        }

        [Fact]
        public void WrongPropertyType_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => TryValidateObject(new WrongPropertyType()));
        }

        private bool TryValidateObject(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
        private class TestModel
        {
            public TestModel(DateTime? fromDate, DateTime? toDate)
            {
                FromDate = fromDate;
                ToDate = toDate;
            }

            public DateTime? FromDate { get; set; }

            [DateNotLessThan(nameof(FromDate))]
            public DateTime? ToDate { get; set; }
        }

        private class TestModelNotNullable
        {
            public TestModelNotNullable(DateTime fromDate, DateTime toDate)
            {
                FromDate = fromDate;
                ToDate = toDate;
            }

            public DateTime FromDate { get; set; }

            [DateNotLessThan(nameof(FromDate))]
            public DateTime ToDate { get; set; }
        }

        private class WrongPropertyName
        {
            public DateTime? FromDate { get; set; }

            [DateNotLessThan("foo")]
            public DateTime? ToDate { get; set; }
        }

        private class WrongPropertyType
        {
            public DateTime? FromDate { get; set; }

            public string Foo { get; set; }

            [DateNotLessThan(nameof(Foo))]
            public DateTime? ToDate { get; set; }
        }
    }
}
