using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public class PfSegment
    {
        public readonly string Key;
        public readonly List<PfSegmentRule> Rules;

        public PfSegment(string key, List<PfSegmentRule> rules)
        {
            Key = key;
            Rules = rules;
        }

        public bool Evaluate(PfStore store, PfUser user)
        {
            return Rules.Any(rule => rule.Evaluate(store, user));
        }
    }
}