using fflags_sdk_cs;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Rollouts
{
    public class PfPercentageRolloutTest
    {
        [Fact]
        public void true_rollout()
        {
            PfPercentageRollout.Create(50).Evaluate("a").Should().BeTrue();
        }
        
        [Fact]
        public void false_rollout()
        {
            PfPercentageRollout.Create(50).Evaluate("A").Should().BeFalse();
        }
    }
}