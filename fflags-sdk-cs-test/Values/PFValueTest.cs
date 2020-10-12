using fflags_sdk_cs.Values;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Values
{
    public class PfValueTest
    {
        [Fact]
        public void Boolean_Value()
        {
            Assert.IsType<PfBooleanValue>(PfValue<object>.Create(true));
        }
        
        [Fact]
        public void String_Value()
        {
            Assert.IsType<PfStringValue>(PfValue<object>.Create("abc"));
        }
        
        [Fact]
        public void Number_Value()
        {
            Assert.IsType<PfNumberValue>(PfValue<object>.Create(1));
        }
    }
}