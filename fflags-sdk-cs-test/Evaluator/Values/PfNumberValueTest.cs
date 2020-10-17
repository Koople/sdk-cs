using fflags_sdk_cs.Values;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Values
{
    public class PfNumberValueTest
    {
        [Fact]
        public void Equality()
        {
            new PfNumberValue(1).Equals(new PfNumberValue(1)).Should().BeTrue("are equals");
            new PfNumberValue(1).Equals(new PfNumberValue(2)).Should().BeFalse("are different");
        }

        [Fact]
        public void Non_equality()
        {
            new PfNumberValue(1).NotEquals(new PfNumberValue(1)).Should().BeFalse("are equals");
            new PfNumberValue(1).NotEquals(new PfNumberValue(2)).Should().BeTrue("are different");
        }

        [Fact]
        public void GreaterThan()
        {
            new PfNumberValue(2).GreaterThan(new PfNumberValue(1)).Should().BeTrue("is greater");
            new PfNumberValue(1).GreaterThan(new PfNumberValue(1)).Should().BeFalse("is equals");
            new PfNumberValue(1).GreaterThan(new PfNumberValue(2)).Should().BeFalse("is lower");
        }

        [Fact]
        public void GreaterThanOrEquals()
        {
            new PfNumberValue(2).GreaterThanOrEquals(new PfNumberValue(1)).Should().BeTrue("is greater");
            new PfNumberValue(2).GreaterThanOrEquals(new PfNumberValue(2)).Should().BeTrue("is equals");
            new PfNumberValue(1).GreaterThanOrEquals(new PfNumberValue(2)).Should().BeFalse("is lower");
        }

        [Fact]
        public void LessThan()
        {
            new PfNumberValue(2).LessThan(new PfNumberValue(1)).Should().BeFalse("is greater");
            new PfNumberValue(1).LessThan(new PfNumberValue(1)).Should().BeFalse("is equals");
            new PfNumberValue(1).LessThan(new PfNumberValue(2)).Should().BeTrue("is lower");
        }

        [Fact]
        public void LessThanOrEquals()
        {
            new PfNumberValue(2).LessThanOrEquals(new PfNumberValue(1)).Should().BeFalse("is greater");
            new PfNumberValue(2).LessThanOrEquals(new PfNumberValue(2)).Should().BeTrue("is equals");
            new PfNumberValue(1).LessThanOrEquals(new PfNumberValue(2)).Should().BeTrue("is lower");
        }
    }
}