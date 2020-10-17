using System.Collections.Generic;
using fflags_sdk_cs;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test
{
    public class PfEvaluatorTest
    {
        [Fact]
        public void Features_evaluation()
        {
            var sut = PfEvaluator.Create(Fixture.Store);

            var result = sut.Evaluate(Fixture.TestUser);

            var expected = new PfEvaluationResult(new Dictionary<string, bool>
            {
                {"disabledForAll", false},
                {"enabledForTestUser", true},
                {"enabledForOtherUser", false},
                {"enabledForSpainAdults", true},
                {"enabledForEeuuAdults", false},
                {"enabledForAll", true},
            });
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}