using System.Collections.Generic;
using Koople.Sdk.Evaluator;
using Koople.Sdk.Evaluator.Rollouts;
using Koople.Sdk.Evaluator.Rules;
using Koople.Sdk.Evaluator.Statements;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Test.Evaluator
{
    public class Fixture
    {
        public static KSegment SpainAdults = new KSegment("spainAdults", new List<KSegmentRule>
        {
            new KSegmentRule(
                1,
                new List<IKEvaluable>
                {
                    new KEqualsStatement("country", new[] {new KStringValue("spain")}),
                    new KGreaterThanOrEqualsStatement("age", new[] {new KNumberValue(18)})
                }
            )
        });

        public static KSegment EeuuAdults = new KSegment("eeuuAdults", new List<KSegmentRule>
        {
            new KSegmentRule(
                1,
                new List<IKEvaluable>
                {
                    new KEqualsStatement("country", new[] {new KStringValue("eeuu")}),
                    new KGreaterThanOrEqualsStatement("age", new[] {new KNumberValue(21)})
                }
            )
        });

        public static KUser TestUser = new KUser("testUser", new Dictionary<string, IKValue>
        {
            {"country", new KStringValue("spain")},
            {"age", new KNumberValue(18)},
        });

        public static KStore Store = new KInMemoryStore(
            new List<KFeatureFlag>
            {
                new KFeatureFlag("disabledForAll", KTargeting.DisabledForAll, new List<string>(),
                    new KInlineRule[] { }, false, KPercentageRollout.Create(100)),
                new KFeatureFlag("enabledForTestUser", KTargeting.EnabledForSomeUsers, new[] {"testUser"},
                    new KInlineRule[] { }, false, KPercentageRollout.Create(100)),
                new KFeatureFlag("enabledForOtherUser", KTargeting.EnabledForSomeUsers, new[] {"otherUser"},
                    new KInlineRule[] { }, false, KPercentageRollout.Create(100)),
                new KFeatureFlag("enabledForSpainAdults", KTargeting.EnabledForSomeUsers, new string[] { },
                    new[]
                    {
                        new KInlineRule(0,
                            new IKEvaluable[]
                            {
                                new KSegmentMatchStatement(new[] {new KSegmentValue(SpainAdults.Key)})
                            })
                    }, true, KPercentageRollout.Create(100)),
                new KFeatureFlag("enabledForEeuuAdults", KTargeting.EnabledForSomeUsers, new string[] { },
                    new[]
                    {
                        new KInlineRule(0,
                            new IKEvaluable[]
                            {
                                new KSegmentMatchStatement(new[] {new KSegmentValue(EeuuAdults.Key)})
                            })
                    }, true, KPercentageRollout.Create(100)),

                new KFeatureFlag("enabledForAll", KTargeting.EnabledForAll, new string[] { }, new KInlineRule[] { },
                    false, KPercentageRollout.Create(100)),
            },
            new KRemoteConfig[] { },
            new List<KSegment> {EeuuAdults, SpainAdults}
        );


        public static KUser empty_user = KUser.Create("empty_user");

        public static KUser premium_user = KUser.Create("premium_user", new[] {new KUserAttribute("premium", true)});

        public static KUser non_premium_user =
            KUser.Create("non_premium_user", new[] {new KUserAttribute("premium", false)});

        public static KUser spain_user = KUser.Create("spain_user", new[] {new KUserAttribute("country", "spain")});

        public static KUser italy_user = KUser.Create("italy_user", new[] {new KUserAttribute("country", "italy")});

        public static KUser eeuu_user = KUser.Create("eeuu_user", new[] {new KUserAttribute("country", "eeuu")});

        public static KUser teen_user = KUser.Create("teen_user", new[] {new KUserAttribute("age", 17)});

        public static KUser adult_user = KUser.Create("adult_user", new[] {new KUserAttribute("age", 18)});

        public static KUser spain_adult_user = KUser.Create("spain_adult_user",
            new[] {new KUserAttribute("country", "spain"), new KUserAttribute("age", 18)});

        public static KUser eeuu_adult_user = KUser.Create("eeuu_adult_user",
            new[] {new KUserAttribute("country", "eeuu"), new KUserAttribute("age", 21)});

        public static KUser himself_user = KUser.Create("himself_user");

        public static KStatement<IKValue> country_equals_spain_statement =
            new KEqualsStatement("country", new[] {new KStringValue("spain")});

        public static KStatement<IKValue> country_equals_italy_statement =
            new KEqualsStatement("country", new[] {new KStringValue("italy")});

        public static KStatement<IKValue> country_equals_eeuu_statement =
            new KEqualsStatement("country", new[] {new KStringValue("eeuu")});

        public static KStatement<KStringValue> country_contains_a_statement =
            new KContainsStatement("country", new[] {new KStringValue("a")});

        public static KStatement<KNumberValue> age_greaterThanOrEquals_18_statement =
            new KGreaterThanOrEqualsStatement("age", new[] {new KNumberValue(18)});

        public static KStatement<KNumberValue> age_greaterThanOrEquals_21_statement =
            new KGreaterThanOrEqualsStatement("age", new[] {new KNumberValue(21)});

        public static KStatement<KBooleanValue> premium_isTruthy_statement = new KIsTruthyStatement("premium");

        public static KStatement<KBooleanValue> premium_isFalsy_statement = new KIsFalsyStatement("premium");

        public static KSegmentRule spain_rule = new KSegmentRule(1, new[] {country_equals_spain_statement});

        public static KSegmentRule spain_adult_rule = new KSegmentRule(1,
            new IKEvaluable[] {country_equals_spain_statement, age_greaterThanOrEquals_18_statement});

        public static KSegmentRule italy_rule = new KSegmentRule(1, new[] {country_equals_italy_statement});

        public static KSegmentRule eeuu_rule = new KSegmentRule(2, new[] {country_equals_eeuu_statement});

        public static KSegmentRule eeuu_adult_rule = new KSegmentRule(2,
            new IKEvaluable[] {country_equals_eeuu_statement, age_greaterThanOrEquals_21_statement});

        public static KSegmentRule premium_users = new KSegmentRule(3, new[] {premium_isTruthy_statement});

        public static KSegmentRule non_premium_users = new KSegmentRule(3, new[] {premium_isFalsy_statement});

        public static KSegment spain_segment = new KSegment("spain_segment", new List<KSegmentRule> {spain_rule});

        public static KSegment italy_segment = new KSegment("italy_segment", new List<KSegmentRule> {italy_rule});

        public static KSegment eeuu_segment = new KSegment("eeuu_segment", new List<KSegmentRule> {eeuu_rule});

        public static KSegment adults_segment =
            new KSegment("adults_segment", new List<KSegmentRule> {eeuu_adult_rule, spain_adult_rule});

        public static KSegment premium_segment =
            new KSegment("premium_segment", new List<KSegmentRule> {premium_users});

        public static KSegment non_premium_segment =
            new KSegment("non_premium_segment", new List<KSegmentRule> {non_premium_users});

        public static KFeatureFlag enabled_for_all_feature = new KFeatureFlag("enabled_for_all_feature",
            KTargeting.EnabledForAll, new string[] { }, new KInlineRule[] { }, false, KPercentageRollout.Create(0));

        public static KFeatureFlag disabled_for_all_feature = new KFeatureFlag("disabled_for_all_feature",
            KTargeting.DisabledForAll, new string[] { }, new KInlineRule[] { }, false, KPercentageRollout.Create(0));

        public static KFeatureFlag enabled_for_himself_feature = new KFeatureFlag("enabled_for_himself_feature",
            KTargeting.EnabledForSomeUsers, new[] {himself_user.GetIdentity()}, new KInlineRule[] { }, false,
            KPercentageRollout.Create(0));

        public static KFeatureFlag enabled_for_spain_or_eeuu_feature = new KFeatureFlag("enabled_for_adults_feature",
            KTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new KInlineRule(0,
                    new[]
                    {
                        new KSegmentMatchStatement(new[]
                            {new KSegmentValue(spain_segment.Key), new KSegmentValue(eeuu_segment.Key)})
                    })
            }, true, KPercentageRollout.Create(100));

        public static KFeatureFlag premium_feature = new KFeatureFlag("premium_feature",
            KTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new KInlineRule(0,
                    new[] {new KSegmentMatchStatement(new[] {new KSegmentValue(premium_segment.Key)})})
            }, true, KPercentageRollout.Create(100));

        public static KFeatureFlag non_premium_feature = new KFeatureFlag("non_premium_feature",
            KTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new KInlineRule(0,
                    new[] {new KSegmentMatchStatement(new[] {new KSegmentValue(non_premium_segment.Key)})})
            }, true, KPercentageRollout.Create(100));

        public static KFeatureFlag fifty_percent_feature = new KFeatureFlag("fifty_percent_feature",
            KTargeting.EnabledForSomeUsers, new string[] { },
            new[]
            {
                new KInlineRule(0, new[] {new KSegmentMatchStatement(new[] {new KSegmentValue(adults_segment.Key)})})
            }, true,
            KPercentageRollout.Create(50));

        public static KFeatureFlag empty_feature = new KFeatureFlag("empty_feature", KTargeting.EnabledForSomeUsers,
            new string[] { }, new KInlineRule[] { }, false, KPercentageRollout.Create(0));

        public static KRemoteConfig roles_remoteConfig = new KRemoteConfig("roles", new[]
        {
            new KRemoteConfigRule(new [] {"ivana"}, new KInlineRule[] { }, "COLLABORATOR"),
            new KRemoteConfigRule(new [] {"ogalindo"}, new KInlineRule[] { }, "ADMIN")
        }, "GUEST");

        public static KStore store = new KInMemoryStore(
            new[]
            {
                enabled_for_all_feature,
                disabled_for_all_feature,
                enabled_for_himself_feature,
                enabled_for_spain_or_eeuu_feature,
                premium_feature,
                non_premium_feature,
                fifty_percent_feature
            },
            new[] {roles_remoteConfig},
            new[]
            {
                spain_segment,
                italy_segment,
                eeuu_segment,
                adults_segment,
                premium_segment,
                non_premium_segment
            });
    }
}