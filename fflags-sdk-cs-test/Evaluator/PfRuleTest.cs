using fflags_sdk_cs_test.Evaluator;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test
{
    public class RuleTest
    {
        [Fact]
        public void true_rule()
        {
            Fixture.spain_adult_rule.Evaluate(Fixture.store, Fixture.spain_adult_user).Should().BeTrue();
        }
        
        [Fact]
        public void false_rule()
        {
            Fixture.spain_adult_rule.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }
        
        [Fact]
        public void evaluate_rule_with_partial_matches_should_be_false()
        {
            Fixture.spain_adult_rule.Evaluate(Fixture.store, Fixture.spain_user).Should().BeFalse();
        }
    }
}