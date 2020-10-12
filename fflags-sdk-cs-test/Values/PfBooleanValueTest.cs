using fflags_sdk_cs.Values;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Values
{
    public class PfBooleanValueTest
    {
        [Fact]
        public void Is_Truthy()
        {
            var truthy = PfBooleanValue.True();
            truthy.IsTruthy().Should().BeTrue();
            truthy.IsFalsy().Should().BeFalse();
        }
        
        [Fact]
        public void Is_Falsy()
        {
            var falsy = PfBooleanValue.False();
            falsy.IsFalsy().Should().BeTrue();
            falsy.IsTruthy().Should().BeFalse();
        }
    }
}