using System;
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
        public readonly List<PfInlineRule> Rules;
        public readonly bool EnableRollout;
        public readonly PfPercentageRollout Rollout;

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
            if (EnableRollout && Rules.Count == 0) return true;

            return Rules.Any(rule => rule.Evaluate(store, user));
        }
    }
}