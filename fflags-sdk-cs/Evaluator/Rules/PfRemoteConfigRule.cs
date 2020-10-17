using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs.Evaluator.Rules
{
    public class PfRemoteConfigRule
    {
        public readonly IEnumerable<string> Identities;
        public readonly IEnumerable<PfInlineRule> Rules;
        public readonly string Value;

        public PfRemoteConfigRule(IEnumerable<string> identities, IEnumerable<PfInlineRule> rules, string value)
        {
            Identities = identities;
            Rules = rules;
            Value = value;
        }

        public bool Evaluate(PfStore store, PfUser user)
        {
            if (Identities.Contains(user.GetIdentity())) return true;

            return Rules.Any(rule => rule.Evaluate(store, user));
        }
    }
}