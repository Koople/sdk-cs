using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Rules;

namespace Koople.Sdk.Evaluator;

public class KRemoteConfig
{
    public string Key { get; }
    public IEnumerable<KRemoteConfigRule> Rules { get; }
    public string DefaultValue { get; }

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