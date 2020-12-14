using Koople.Sdk.Values;
using FluentAssertions;
using Xunit;

namespace Koople.Sdk.Test.Values
{
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
}