using System.Collections.Generic;
using fflags_sdk_cs;
using fflags_sdk_cs.Evaluator;
using fflags_sdk_cs.Evaluator.Statements;
using fflags_sdk_cs.Evaluator.Values;
using fflags_sdk_cs.Statements;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs_test
{
    public class Fixture
    {
        public static PfSegment SpainAdults = new PfSegment("spainAdults", new List<PfSegmentRule>
        {
            new PfSegmentRule(
                1,
                new List<IPfEvaluable>
                {
                    new PfEqualsStatement("country", new[] {new PfStringValue("spain")}),
                    new PfGreaterThanOrEqualsStatement("age", new[] {new PfNumberValue(18)})
                }
            )
        });

        public static PfSegment EeuuAdults = new PfSegment("eeuuAdults", new List<PfSegmentRule>
        {
            new PfSegmentRule(
                1,
                new List<IPfEvaluable>
                {
                    new PfEqualsStatement("country", new[] {new PfStringValue("eeuu")}),
                    new PfGreaterThanOrEqualsStatement("age", new[] {new PfNumberValue(21)})
                }
            )
        });

        public static PfUser TestUser = new PfUser("testUser", new Dictionary<string, IPfValue>
        {
            {"country", new PfStringValue("spain")},
            {"age", new PfNumberValue(18)},
        });

        public static PfStore Store = new PfInMemoryStore(
            new List<PfFeatureFlag>
            {
                new PfFeatureFlag("disabledForAll", PfTargeting.DisabledForAll, new List<string>(),
                    new PfInlineRule[] { }, false, PfPercentageRollout.Create(100)),
                new PfFeatureFlag("enabledForTestUser", PfTargeting.EnabledForSomeUsers, new[] {"testUser"},
                    new PfInlineRule[] { }, false, PfPercentageRollout.Create(100)),
                new PfFeatureFlag("enabledForOtherUser", PfTargeting.EnabledForSomeUsers, new[] {"otherUser"},
                    new PfInlineRule[] { }, false, PfPercentageRollout.Create(100)),
                new PfFeatureFlag("enabledForSpainAdults", PfTargeting.EnabledForSomeUsers, new string[] { },
                    new[]
                    {
                        new PfInlineRule(0,
                            new IPfEvaluable[]
                            {
                                new PfSegmentMatchStatement(new[] {new PfSegmentValue(SpainAdults.Key)})
                            })
                    }, true, PfPercentageRollout.Create(100)),
                new PfFeatureFlag("enabledForEeuuAdults", PfTargeting.EnabledForSomeUsers, new string[] { },
                    new[]
                    {
                        new PfInlineRule(0,
                            new IPfEvaluable[]
                            {
                                new PfSegmentMatchStatement(new[] {new PfSegmentValue(EeuuAdults.Key)})
                            })
                    }, true, PfPercentageRollout.Create(100)),

                new PfFeatureFlag("enabledForAll", PfTargeting.EnabledForAll, new string[] { }, new PfInlineRule[] { },
                    false, PfPercentageRollout.Create(100)),
            },
            new List<PfSegment> {EeuuAdults, SpainAdults}
        );


        public static PfUser empty_user = PfUser.Create("empty_user");

        public static PfUser premium_user = PfUser.Create("premium_user", new[] {new PfUserAttribute("premium", true)});

        public static PfUser non_premium_user =
            PfUser.Create("non_premium_user", new[] {new PfUserAttribute("premium", false)});

        public static PfUser spain_user = PfUser.Create("spain_user", new[] {new PfUserAttribute("country", "spain")});

        public static PfUser italy_user = PfUser.Create("italy_user", new[] {new PfUserAttribute("country", "italy")});

        public static PfUser eeuu_user = PfUser.Create("eeuu_user", new[] {new PfUserAttribute("country", "eeuu")});

        public static PfUser teen_user = PfUser.Create("teen_user", new[] {new PfUserAttribute("age", 17)});

        public static PfUser adult_user = PfUser.Create("adult_user", new[] {new PfUserAttribute("age", 18)});

        public static PfUser spain_adult_user = PfUser.Create("spain_adult_user",
            new[] {new PfUserAttribute("country", "spain"), new PfUserAttribute("age", 18)});

        public static PfUser eeuu_adult_user = PfUser.Create("eeuu_adult_user",
            new[] {new PfUserAttribute("country", "eeuu"), new PfUserAttribute("age", 21)});

        public static PfUser himself_user = PfUser.Create("himself_user");

        public static PfStatement<IPfValue> country_equals_spain_statement =
            new PfEqualsStatement("country", new[] {new PfStringValue("spain")});

        public static PfStatement<IPfValue> country_equals_italy_statement =
            new PfEqualsStatement("country", new[] {new PfStringValue("italy")});

        public static PfStatement<IPfValue> country_equals_eeuu_statement =
            new PfEqualsStatement("country", new[] {new PfStringValue("eeuu")});

        public static PfStatement<PfStringValue> country_contains_a_statement =
            new PfContainsStatement("country", new[] {new PfStringValue("a")});

        public static PfStatement<PfNumberValue> age_greaterThanOrEquals_18_statement =
            new PfGreaterThanOrEqualsStatement("age", new[] {new PfNumberValue(18)});

        public static PfStatement<PfNumberValue> age_greaterThanOrEquals_21_statement =
            new PfGreaterThanOrEqualsStatement("age", new[] {new PfNumberValue(21)});

        public static PfStatement<PfBooleanValue> premium_isTruthy_statement = new PfIsTruthyStatement("premium");

        public static PfStatement<PfBooleanValue> premium_isFalsy_statement = new PfIsFalsyStatement("premium");

        public static PfSegmentRule spain_rule = new PfSegmentRule(1, new[] {country_equals_spain_statement});

        public static PfSegmentRule spain_adult_rule = new PfSegmentRule(1,
            new IPfEvaluable[] {country_equals_spain_statement, age_greaterThanOrEquals_18_statement});

        public static PfSegmentRule italy_rule = new PfSegmentRule(1, new[] {country_equals_italy_statement});

        public static PfSegmentRule eeuu_rule = new PfSegmentRule(2, new[] {country_equals_eeuu_statement});

        public static PfSegmentRule eeuu_adult_rule = new PfSegmentRule(2,
            new IPfEvaluable[] {country_equals_eeuu_statement, age_greaterThanOrEquals_21_statement});

        public static PfSegmentRule premium_users = new PfSegmentRule(3, new[] {premium_isTruthy_statement});

        public static PfSegmentRule non_premium_users = new PfSegmentRule(3, new[] {premium_isFalsy_statement});

        public static PfSegment spain_segment = new PfSegment("spain_segment", new List<PfSegmentRule> {spain_rule});

        public static PfSegment italy_segment = new PfSegment("italy_segment", new List<PfSegmentRule> {italy_rule});

        public static PfSegment eeuu_segment = new PfSegment("eeuu_segment", new List<PfSegmentRule> {eeuu_rule});

        public static PfSegment adults_segment =
            new PfSegment("adults_segment", new List<PfSegmentRule> {eeuu_adult_rule, spain_adult_rule});

        public static PfSegment premium_segment =
            new PfSegment("premium_segment", new List<PfSegmentRule> {premium_users});

        public static PfSegment non_premium_segment =
            new PfSegment("non_premium_segment", new List<PfSegmentRule> {non_premium_users});

        public static PfFeatureFlag enabled_for_all_feature = new PfFeatureFlag("enabled_for_all_feature",
            PfTargeting.EnabledForAll, new string[] { }, new PfInlineRule[] { }, false, PfPercentageRollout.Create(0));

        public static PfFeatureFlag disabled_for_all_feature = new PfFeatureFlag("disabled_for_all_feature",
            PfTargeting.DisabledForAll, new string[] { }, new PfInlineRule[] { }, false, PfPercentageRollout.Create(0));

        public static PfFeatureFlag enabled_for_himself_feature = new PfFeatureFlag("enabled_for_himself_feature",
            PfTargeting.EnabledForSomeUsers, new[] {himself_user.GetIdentity()}, new PfInlineRule[] { }, false,
            PfPercentageRollout.Create(0));

        public static PfFeatureFlag enabled_for_spain_or_eeuu_feature = new PfFeatureFlag("enabled_for_adults_feature",
            PfTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new PfInlineRule(0,
                    new[]
                    {
                        new PfSegmentMatchStatement(new[]
                            {new PfSegmentValue(spain_segment.Key), new PfSegmentValue(eeuu_segment.Key)})
                    })
            }, true, PfPercentageRollout.Create(100));

        public static PfFeatureFlag premium_feature = new PfFeatureFlag("premium_feature",
            PfTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new PfInlineRule(0,
                    new[] {new PfSegmentMatchStatement(new[] {new PfSegmentValue(premium_segment.Key)})})
            }, true, PfPercentageRollout.Create(100));

        public static PfFeatureFlag non_premium_feature = new PfFeatureFlag("non_premium_feature",
            PfTargeting.EnabledForSomeUsers, new string[] { }, new[]
            {
                new PfInlineRule(0,
                    new[] {new PfSegmentMatchStatement(new[] {new PfSegmentValue(non_premium_segment.Key)})})
            }, true, PfPercentageRollout.Create(100));

        public static PfFeatureFlag fifty_percent_feature = new PfFeatureFlag("fifty_percent_feature",
            PfTargeting.EnabledForSomeUsers, new string[] { }, new [] { new PfInlineRule(0, new []{ new PfSegmentMatchStatement(new []{ new PfSegmentValue(adults_segment.Key) }) })  }, true,
            PfPercentageRollout.Create(50));

        public static PfFeatureFlag empty_feature = new PfFeatureFlag("empty_feature", PfTargeting.EnabledForSomeUsers,
            new string[] { }, new PfInlineRule[] { }, false, PfPercentageRollout.Create(0));

        // public static PFRemoteConfig roles_remoteConfig = new PFRemoteConfig("roles", new List<PFRemoteConfigRule>(), "GUEST");

        public static PfStore store = new PfInMemoryStore(new []
        {
            enabled_for_all_feature,
            disabled_for_all_feature,
            enabled_for_himself_feature,
            enabled_for_spain_or_eeuu_feature,
            premium_feature,
            non_premium_feature,
            fifty_percent_feature
        }, new []
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