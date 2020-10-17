using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public class PfEvaluationResult
    {
        public readonly Dictionary<string, bool> _features;

        public PfEvaluationResult(Dictionary<string, bool> features)
        {
            _features = features;
        }
    }

    public class PfEvaluator
    {
        private readonly PfStore _store;

        private PfEvaluator(PfStore store)
        {
            _store = store;
        }

        public static PfEvaluator Create(IEnumerable<PfFeatureFlag> featureFlags, IEnumerable<PfSegment> segments) =>
            new PfEvaluator(new PfInMemoryStore(featureFlags, segments));

        public static PfEvaluator Create(PfStore store) => new PfEvaluator(store);

        public PfEvaluationResult Evaluate(PfUser user)
        {
            var evaluatedFlags = _store.GetFeatureFlags().ToDictionary(x => x.Key, flag => flag.Evaluate(_store, user));
            return new PfEvaluationResult(evaluatedFlags);
        }

        public bool Evaluate(string feature, PfUser user) =>
            _store.GetFeatureFlag(feature)?.Evaluate(_store, user) ?? false;
    }
}