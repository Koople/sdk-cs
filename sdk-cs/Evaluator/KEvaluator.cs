using System.Collections.Generic;
using System.Linq;

namespace Koople.Sdk.Evaluator;

public class KEvaluationResult
{
    public readonly Dictionary<string, bool> Features;

    public KEvaluationResult(Dictionary<string, bool> features)
    {
        Features = features;
    }
}

public class KEvaluator
{
    private readonly KStore _store;

    private KEvaluator(KStore store)
    {
        _store = store;
    }

    public static KEvaluator Create(IEnumerable<KFeatureFlag> featureFlags,
        IEnumerable<KRemoteConfig> remoteConfigs, IEnumerable<KSegment> segments) =>
        new KEvaluator(new KInMemoryStore(featureFlags, remoteConfigs, segments));

    public static KEvaluator Create(KStore store) => new KEvaluator(store);

    public KEvaluationResult Evaluate(KUser user)
    {
        var evaluatedFlags = _store.GetFeatureFlags().ToDictionary(x => x.Key, flag => flag.Evaluate(_store, user));
        return new KEvaluationResult(evaluatedFlags);
    }

    public bool Evaluate(string feature, KUser user) =>
        _store.GetFeatureFlag(feature)?.Evaluate(_store, user) ?? false;

    public string ValueOf(string remoteConfig, KUser user, string defaultValue)
    {
        var rc = _store.GetRemoteConfig(remoteConfig);
        return rc?.Evaluate(_store, user) ?? defaultValue;
    }
}