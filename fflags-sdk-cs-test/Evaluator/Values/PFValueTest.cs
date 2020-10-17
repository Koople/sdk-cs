using fflags_sdk_cs.Evaluator.Values;
using fflags_sdk_cs.Values;
using Xunit;

namespace fflags_sdk_cs_test.Evaluator.Values
{
    public class PfValueTest
    {
        [Fact]
        public void Boolean_Value()
        {
            Assert.IsType<PfBooleanValue>(IPfValue.Create(true));
        }
        
        [Fact]
        public void String_Value()
        {
            Assert.IsType<PfStringValue>(IPfValue.Create("abc"));
        }
        
        [Fact]
        public void Number_Value()
        {
            Assert.IsType<PfNumberValue>(IPfValue.Create(1));
        }
    }
}