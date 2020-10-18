using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs.Evaluator
{
    public class PfEvaluationResult
    {
        public readonly Dictionary<string, bool> Features;

        public PfEvaluationResult(Dictionary<string, bool> features)
        {
            Features = features;
        }
    }

    public class PfEvaluator
    {
        private readonly PfStore _store;

        private PfEvaluator(PfStore store)
        {
            _store = store;
        }

        public static PfEvaluator Create(IEnumerable<PfFeatureFlag> featureFlags,
            IEnumerable<PfRemoteConfig> remoteConfigs, IEnumerable<PfSegment> segments) =>
            new PfEvaluator(new PfInMemoryStore(featureFlags, remoteConfigs, segments));

        public static PfEvaluator Create(PfStore store) => new PfEvaluator(store);

        public PfEvaluationResult Evaluate(PfUser user)
        {
            var evaluatedFlags = _store.GetFeatureFlags().ToDictionary(x => x.Key, flag => flag.Evaluate(_store, user));
            return new PfEvaluationResult(evaluatedFlags);
        }

        public bool Evaluate(string feature, PfUser user) =>
            _store.GetFeatureFlag(feature)?.Evaluate(_store, user) ?? false;

        public string ValueOf(string remoteConfig, PfUser user, string defaultValue)
        {
            var rc = _store.GetRemoteConfig(remoteConfig);
            return rc?.Evaluate(_store, user) ?? defaultValue;
        }
    }
}