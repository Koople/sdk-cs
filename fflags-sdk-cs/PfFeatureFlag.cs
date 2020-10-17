using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public enum PfTargeting
    {
        DisabledForAll,
        EnabledForSomeUsers,
        EnabledForAll
    }

    public class PfFeatureFlag
    {
        public readonly string Key;
        public readonly PfTargeting Targeting;
        public readonly IEnumerable<string> Identities;
        public readonly IEnumerable<PfInlineRule> Rules;
        public readonly bool EnableRollout;
        public readonly PfPercentageRollout Rollout;

        public PfFeatureFlag(string key, PfTargeting targeting, IEnumerable<string> identities,
            IEnumerable<PfInlineRule> rules, bool enableRollout, PfPercentageRollout rollout)
        {
            Key = key;
            Targeting = targeting;
            Identities = identities;
            Rules = rules;
            EnableRollout = enableRollout;
            Rollout = rollout;
        }

        public bool Evaluate(PfStore store, PfUser user) => Targeting switch
        {
            PfTargeting.DisabledForAll => false,
            PfTargeting.EnabledForAll => true,
            PfTargeting.EnabledForSomeUsers => _Evaluate(store, user),
            _ => false
        };

        private bool _Evaluate(PfStore store, PfUser user)
        {
            if (Identities.Contains(user.GetIdentity())) return true;
            if (EnableRollout && !Rollout.Evaluate(Key + user.GetIdentity())) return false;
            if (EnableRollout && Rules.ToList().Count == 0) return true;

            return Rules.Any(rule => rule.Evaluate(store, user));
        }
    }
}