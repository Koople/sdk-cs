using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Koople.Sdk.Evaluator.Rollouts;
using Koople.Sdk.Evaluator.Rules;

namespace Koople.Sdk.Evaluator;

public enum KTargeting
{
    [EnumMember(Value = "DISABLED_FOR_ALL")]
    DisabledForAll,

    [EnumMember(Value = "ENABLED_FOR_SOME_USERS")]
    EnabledForSomeUsers,

    [EnumMember(Value = "ENABLED_FOR_ALL")]
    EnabledForAll
}

public class KFeatureFlag
{
    public string Key { get; }
    public KTargeting Targeting { get; }
    public IEnumerable<string> Identities { get; }
    public IEnumerable<KInlineRule> Rules { get; }
    public bool EnableRollout { get; }
    public KPercentageRollout Rollout { get; }

    public KFeatureFlag(string key, KTargeting targeting, IEnumerable<string> identities,
        IEnumerable<KInlineRule> rules, bool enableRollout, KPercentageRollout rollout)
    {
        Key = key;
        Targeting = targeting;
        Identities = identities;
        Rules = rules;
        EnableRollout = enableRollout;
        Rollout = rollout;
    }

    public bool Evaluate(KStore store, KUser user)
    {
        switch (Targeting)
        {
            case KTargeting.DisabledForAll:
                return false;
            case KTargeting.EnabledForAll:
                return true;
            case KTargeting.EnabledForSomeUsers:
                return _Evaluate(store, user);
            default:
                return false;
        }
    }

    private bool _Evaluate(KStore store, KUser user)
    {
        if (Identities.Contains(user.GetIdentity())) return true;
        if (EnableRollout && !Rollout.Evaluate(Key + user.GetIdentity())) return false;
        if (EnableRollout && Rules.ToList().Count == 0) return true;

        return Rules.Any(rule => rule.Evaluate(store, user));
    }
}