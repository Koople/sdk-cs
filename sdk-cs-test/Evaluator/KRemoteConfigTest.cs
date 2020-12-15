using Koople.Sdk;
using FluentAssertions;
using Koople.Sdk.Evaluator;
using Xunit;

namespace Koople.Sdk.Test.Evaluator
{
    public class KRemoteConfigTest
    {
        [Fact]
        public void evaluate_ivana_should_be_COLLABORATOR()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, KUser.Create("ivana")).Should()
                .BeEquivalentTo("COLLABORATOR");
        }
        
        [Fact]
        public void evaluate_oscar_should_be_ADMIN()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, KUser.Create("ogalindo")).Should()
                .BeEquivalentTo("ADMIN");
        }
        
        [Fact]
        public void evaluate_other_should_be_GUEST()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, KUser.Create("whatever")).Should()
                .BeEquivalentTo("GUEST");
        }
    }
}