using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Rules;

namespace Koople.Sdk.Evaluator;

public class KSegment
{
    public readonly string Key;
    public readonly List<KSegmentRule> Rules;

    public KSegment(string key, List<KSegmentRule> rules)
    {
        Key = key;
        Rules = rules;
    }

    public bool Evaluate(KStore store, KUser user)
    {
        return Rules.Any(rule => rule.Evaluate(store, user));
    }
}