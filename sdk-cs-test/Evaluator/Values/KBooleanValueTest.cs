using FluentAssertions;
using Koople.Sdk.Evaluator.Values;
using Xunit;

namespace Koople.Sdk.Test.Evaluator.Values;

public class KBooleanValueTest
{
    [Fact]
    public void Is_Truthy()
    {
        var truthy = KBooleanValue.True();
        truthy.IsTruthy().Should().BeTrue();
        truthy.IsFalsy().Should().BeFalse();
    }
        
    [Fact]
    public void Is_Falsy()
    {
        var falsy = KBooleanValue.False();
        falsy.IsFalsy().Should().BeTrue();
        falsy.IsTruthy().Should().BeFalse();
    }
}