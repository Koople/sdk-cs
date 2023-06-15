using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Rules;

namespace Koople.Sdk.Evaluator;

public class KSegment
{
    public string Key { get; }
    public List<KSegmentRule> Rules { get; }

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