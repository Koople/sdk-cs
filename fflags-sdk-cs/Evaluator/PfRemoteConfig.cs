using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Evaluator.Rules;

namespace fflags_sdk_cs.Evaluator
{
    public class PfRemoteConfig
    {
        public readonly string Key;
        public readonly IEnumerable<PfRemoteConfigRule> Rules;
        public readonly string DefaultValue;

        public PfRemoteConfig(string key, IEnumerable<PfRemoteConfigRule> rules, string defaultValue)
        {
            Key = key;
            Rules = rules;
            DefaultValue = defaultValue;
        }

        public string Evaluate(PfStore store, PfUser user)
        {
            return Rules.Aggregate(DefaultValue, (s, rule) => rule.Evaluate(store, user) ? rule.Value : s);
        }
    }
}