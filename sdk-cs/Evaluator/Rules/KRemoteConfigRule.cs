using System.Collections.Generic;
using System.Linq;

namespace Koople.Sdk.Evaluator.Rules;

public class KRemoteConfigRule
{
    public IEnumerable<string> Identities { get; }
    public IEnumerable<KInlineRule> Rules { get; }
    public string Value { get; }

    public KRemoteConfigRule(IEnumerable<string> identities, IEnumerable<KInlineRule> rules, string value)
    {
        Identities = identities;
        Rules = rules;
        Value = value;
    }

    public bool Evaluate(KStore store, KUser user)
    {
        if (Identities.Contains(user.GetIdentity())) return true;

        return Rules.Any(rule => rule.Evaluate(store, user));
    }
}