using fflags_sdk_cs.Values;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Values
{
    public class PfStringValueTest
    {
        [Fact]
        public void Equality()
        {
            new PfStringValue("a").Equals(new PfStringValue("a")).Should().BeTrue("are equals");
            new PfStringValue("a").Equals(new PfStringValue("b")).Should().BeFalse("are different");
        }
        
        [Fact]
        public void Non_Equality()
        {
            new PfStringValue("a").NotEquals(new PfStringValue("a")).Should().BeFalse("are equals");
            new PfStringValue("a").NotEquals(new PfStringValue("b")).Should().BeTrue("are different");
        }

        [Fact]
        public void Empty()
        {
            new PfStringValue("").IsEmpty().Should().BeTrue("empty string \"\"");
            new PfStringValue(" ").IsEmpty().Should().BeTrue("whitespace \" \"");
            new PfStringValue("a").IsEmpty().Should().BeFalse("character \"a\"");
        }

        [Fact]
        public void Not_Empty()
        {
            new PfStringValue("").IsNotEmpty().Should().BeFalse("empty string \"\"");
            new PfStringValue(" ").IsNotEmpty().Should().BeFalse("whitespace \" \"");
            new PfStringValue("a").IsNotEmpty().Should().BeTrue("character \"a\"");
        }

        [Fact]
        public void Contains()
        {
            new PfStringValue("abc").Contains(new PfStringValue("a")).Should().BeTrue("'a' is in 'abc' value");
            new PfStringValue("abc").Contains(new PfStringValue("d")).Should().BeFalse("'d' is not in 'abc' value");
        }
    }
}