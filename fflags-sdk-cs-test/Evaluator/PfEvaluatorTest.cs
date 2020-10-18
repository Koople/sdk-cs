using System.Collections.Generic;
using fflags_sdk_cs;
using fflags_sdk_cs_test.Evaluator;
using fflags_sdk_cs.Evaluator;
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
        
        [Fact]
        public void Feature_false_evaluation()
        {
            var sut = PfEvaluator.Create(Fixture.Store);

            var result = sut.Evaluate("disabledForAll", Fixture.TestUser);

            result.Should().BeFalse();
        }
        
        [Fact]
        public void Feature_true_evaluation()
        {
            var sut = PfEvaluator.Create(Fixture.Store);

            var result = sut.Evaluate("enabledForAll", Fixture.TestUser);

            result.Should().BeTrue();
        }
    }
}