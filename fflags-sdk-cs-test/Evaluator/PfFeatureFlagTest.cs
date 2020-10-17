using System.Collections.Generic;
using fflags_sdk_cs;
using fflags_sdk_cs.Statements;
using fflags_sdk_cs.Values;
using FluentAssertions;
using Xunit;

namespace fflags_sdk_cs_test
{
    public class PfFeatureFlagTest
    {
        [Fact]
        public void evaluate_feature_enabled_for_all_should_true()
        {
            Fixture.enabled_for_all_feature.Evaluate(Fixture.store, Fixture.empty_user).Should().BeTrue();
        }

        [Fact]
        public void evaluate_feature_disabled_for_all_should_false()
        {
            Fixture.disabled_for_all_feature.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }

        [Fact]
        public void evaluate_feature_enabled_for_himself_should_true()
        {
            Fixture.enabled_for_himself_feature.Evaluate(Fixture.store, Fixture.himself_user).Should().BeTrue();
        }

        [Fact]
        public void evaluate_feature_enabled_for_himself_should_false()
        {
            Fixture.enabled_for_himself_feature.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }

        [Fact]
        public void evaluate_feature_enabled_for_spain_or_eeuu_with_matches_into_first_segment_should_true()
        {
            Fixture.enabled_for_spain_or_eeuu_feature.Evaluate(Fixture.store, Fixture.spain_user).Should().BeTrue();
        }

        [Fact]
        public void evaluate_feature_enabled_for_spain_or_eeuu_with_matches_into_second_segment_should_true()
        {
            Fixture.enabled_for_spain_or_eeuu_feature.Evaluate(Fixture.store, Fixture.eeuu_user).Should().BeTrue();
        }

        [Fact]
        public void evaluate_feature_enabled_for_spain_or_eeuu_feature_should_false()
        {
            Fixture.enabled_for_spain_or_eeuu_feature.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }

        [Fact]
        public void premium()
        {
            Fixture.premium_feature.Evaluate(Fixture.store, Fixture.premium_user).Should().BeTrue();
        }

        [Fact]
        public void non_premium()
        {
            Fixture.premium_feature.Evaluate(Fixture.store, Fixture.non_premium_user).Should().BeFalse();
        }

        [Fact]
        public void should_include_user_in_the_release()
        {
            var user1 = PfUser.Create("oscar",
                new[] {new PfUserAttribute("age", 32), new PfUserAttribute("country", "spain")});
            var user2 = PfUser.Create("serrano",
                new[] {new PfUserAttribute("age", 32), new PfUserAttribute("country", "spain")});
            Fixture.fifty_percent_feature.Evaluate(Fixture.store, user1).Should().BeFalse();
            Fixture.fifty_percent_feature.Evaluate(Fixture.store, user2).Should().BeTrue();
        }

        [Fact]
        public void if_no_identities_and_no_segments_feature_is_disabled()
        {
            Fixture.empty_feature.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }

        [Fact]
        public void if_match_rules_and_enabled_rollout_0_percent_should_return_false()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new PfInlineRule[] { }, true, PfPercentageRollout.Create(0));
            sut.Evaluate(Fixture.store, Fixture.spain_user).Should().BeFalse();
        }

        [Fact]
        public void if_match_rules_and_enabled_rollout_100_percent_should_return_true()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new List<PfInlineRule>
                {
                    new PfInlineRule(0, new[] {new PfEqualsStatement("country", new[] {PfStringValue.Create("spain")})})
                },
                true, PfPercentageRollout.Create(100));
            sut.Evaluate(Fixture.store, Fixture.spain_user).Should().BeTrue();
        }

        [Fact]
        public void if_match_rules_and_disabled_rollout_should_return_true()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new List<PfInlineRule>
                {
                    new PfInlineRule(0, new[] {new PfEqualsStatement("country", new[] {PfStringValue.Create("spain")})})
                },
                false, PfPercentageRollout.Create(100));
            sut.Evaluate(Fixture.store, Fixture.spain_user).Should().BeTrue();
        }

        [Fact]
        public void if_no_rules_and_enabled_rollout_0_percent_should_return_true()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new PfInlineRule[] { }, true, PfPercentageRollout.Create(0));
            sut.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }

        [Fact]
        public void if_no_rules_and_enabled_rollout_100_percent_should_return_true()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new PfInlineRule[] { }, true, PfPercentageRollout.Create(100));
            sut.Evaluate(Fixture.store, Fixture.empty_user).Should().BeTrue();
        }

        [Fact]
        public void if_no_rules_and_disabled_rollout_should_return_false()
        {
            var sut = new PfFeatureFlag("sut", PfTargeting.EnabledForSomeUsers, new string[] { },
                new PfInlineRule[] { }, false, PfPercentageRollout.Create(100));
            sut.Evaluate(Fixture.store, Fixture.empty_user).Should().BeFalse();
        }
    }
}