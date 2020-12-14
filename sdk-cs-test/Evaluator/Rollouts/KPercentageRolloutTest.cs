using Koople.Sdk;
using FluentAssertions;
using Xunit;

namespace Koople.Sdk.Test.Rollouts
{
    public class KPercentageRolloutTest
    {
        [Fact]
        public void true_rollout()
        {
            KPercentageRollout.Create(50).Evaluate("a").Should().BeTrue();
        }
        
        [Fact]
        public void false_rollout()
        {
            KPercentageRollout.Create(50).Evaluate("A").Should().BeFalse();
        }
    }
}