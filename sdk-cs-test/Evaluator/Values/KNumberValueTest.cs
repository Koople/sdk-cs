using FluentAssertions;
using Koople.Sdk.Evaluator.Values;
using Xunit;

namespace Koople.Sdk.Test.Evaluator.Values;

public class KNumberValueTest
{
    [Fact]
    public void Equality()
    {
        new KNumberValue(1).Equals(new KNumberValue(1)).Should().BeTrue("are equals");
        new KNumberValue(1).Equals(new KNumberValue(2)).Should().BeFalse("are different");
    }

    [Fact]
    public void Non_equality()
    {
        new KNumberValue(1).NotEquals(new KNumberValue(1)).Should().BeFalse("are equals");
        new KNumberValue(1).NotEquals(new KNumberValue(2)).Should().BeTrue("are different");
    }

    [Fact]
    public void GreaterThan()
    {
        new KNumberValue(2).GreaterThan(new KNumberValue(1)).Should().BeTrue("is greater");
        new KNumberValue(1).GreaterThan(new KNumberValue(1)).Should().BeFalse("is equals");
        new KNumberValue(1).GreaterThan(new KNumberValue(2)).Should().BeFalse("is lower");
    }

    [Fact]
    public void GreaterThanOrEquals()
    {
        new KNumberValue(2).GreaterThanOrEquals(new KNumberValue(1)).Should().BeTrue("is greater");
        new KNumberValue(2).GreaterThanOrEquals(new KNumberValue(2)).Should().BeTrue("is equals");
        new KNumberValue(1).GreaterThanOrEquals(new KNumberValue(2)).Should().BeFalse("is lower");
    }

    [Fact]
    public void LessThan()
    {
        new KNumberValue(2).LessThan(new KNumberValue(1)).Should().BeFalse("is greater");
        new KNumberValue(1).LessThan(new KNumberValue(1)).Should().BeFalse("is equals");
        new KNumberValue(1).LessThan(new KNumberValue(2)).Should().BeTrue("is lower");
    }

    [Fact]
    public void LessThanOrEquals()
    {
        new KNumberValue(2).LessThanOrEquals(new KNumberValue(1)).Should().BeFalse("is greater");
        new KNumberValue(2).LessThanOrEquals(new KNumberValue(2)).Should().BeTrue("is equals");
        new KNumberValue(1).LessThanOrEquals(new KNumberValue(2)).Should().BeTrue("is lower");
    }
}