using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Rules;

namespace Koople.Sdk.Evaluator;

public class KRemoteConfig
{
    public readonly string Key;
    public readonly IEnumerable<KRemoteConfigRule> Rules;
    public readonly string DefaultValue;

    public KRemoteConfig(string key, IEnumerable<KRemoteConfigRule> rules, string defaultValue)
    {
        Key = key;
        Rules = rules;
        DefaultValue = defaultValue;
    }

    public string Evaluate(KStore store, KUser user)
    {
        return Rules.Aggregate(DefaultValue, (s, rule) => rule.Evaluate(store, user) ? rule.Value : s);
    }
}