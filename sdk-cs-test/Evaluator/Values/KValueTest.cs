using Koople.Sdk.Evaluator.Values;
using Koople.Sdk.Values;
using Xunit;

namespace Koople.Sdk.Test.Evaluator.Values
{
    public class KValueTest
    {
        [Fact]
        public void Boolean_Value()
        {
            Assert.IsType<KBooleanValue>(IKValue.Create(true));
        }
        
        [Fact]
        public void String_Value()
        {
            Assert.IsType<KStringValue>(IKValue.Create("abc"));
        }
        
        [Fact]
        public void Number_Value()
        {
            Assert.IsType<KNumberValue>(IKValue.Create(1));
        }
    }
}