using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace fflags_sdk_cs
{
    public enum PfTargeting
    {
        [EnumMember(Value = "DISABLED_FOR_ALL")]
        DisabledForAll,

        [EnumMember(Value = "ENABLED_FOR_SOME_USERS")]
        EnabledForSomeUsers,

        [EnumMember(Value = "ENABLED_FOR_ALL")]
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

        public bool Evaluate(PfStore store, PfUser user)
        {
            switch (Targeting)
            {
                case PfTargeting.DisabledForAll:
                    return false;
                case PfTargeting.EnabledForAll:
                    return true;
                case PfTargeting.EnabledForSomeUsers:
                    return _Evaluate(store, user);
                default:
                    return false;
            }
        }

        private bool _Evaluate(PfStore store, PfUser user)
        {
            if (Identities.Contains(user.GetIdentity())) return true;
            if (EnableRollout && !Rollout.Evaluate(Key + user.GetIdentity())) return false;
            if (EnableRollout && Rules.ToList().Count == 0) return true;

            return Rules.Any(rule => rule.Evaluate(store, user));
        }
    }
}