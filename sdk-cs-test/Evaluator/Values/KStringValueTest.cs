using FluentAssertions;
using Koople.Sdk.Evaluator.Values;
using Xunit;

namespace Koople.Sdk.Test.Values
{
    public class KStringValueTest
    {
        [Fact]
        public void Equality()
        {
            new KStringValue("a").Equals(new KStringValue("a")).Should().BeTrue("are equals");
            new KStringValue("a").Equals(new KStringValue("b")).Should().BeFalse("are different");
        }
        
        [Fact]
        public void Non_Equality()
        {
            new KStringValue("a").NotEquals(new KStringValue("a")).Should().BeFalse("are equals");
            new KStringValue("a").NotEquals(new KStringValue("b")).Should().BeTrue("are different");
        }

        [Fact]
        public void Empty()
        {
            new KStringValue("").IsEmpty().Should().BeTrue("empty string \"\"");
            new KStringValue(" ").IsEmpty().Should().BeTrue("whitespace \" \"");
            new KStringValue("a").IsEmpty().Should().BeFalse("character \"a\"");
        }

        [Fact]
        public void Not_Empty()
        {
            new KStringValue("").IsNotEmpty().Should().BeFalse("empty string \"\"");
            new KStringValue(" ").IsNotEmpty().Should().BeFalse("whitespace \" \"");
            new KStringValue("a").IsNotEmpty().Should().BeTrue("character \"a\"");
        }

        [Fact]
        public void Contains()
        {
            new KStringValue("abc").Contains(new KStringValue("a")).Should().BeTrue("'a' is in 'abc' value");
            new KStringValue("abc").Contains(new KStringValue("d")).Should().BeFalse("'d' is not in 'abc' value");
        }
    }
}