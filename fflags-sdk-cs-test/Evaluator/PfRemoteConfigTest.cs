using fflags_sdk_cs;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test.Evaluator
{
    public class PfRemoteConfigTest
    {
        [Fact]
        public void evaluate_ivana_should_be_COLLABORATOR()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, PfUser.Create("ivana")).Should()
                .BeEquivalentTo("COLLABORATOR");
        }
        
        [Fact]
        public void evaluate_oscar_should_be_ADMIN()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, PfUser.Create("ogalindo")).Should()
                .BeEquivalentTo("ADMIN");
        }
        
        [Fact]
        public void evaluate_other_should_be_GUEST()
        {
            Fixture.roles_remoteConfig.Evaluate(Fixture.store, PfUser.Create("whatever")).Should()
                .BeEquivalentTo("GUEST");
        }
    }
}