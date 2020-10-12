using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public class PfEvaluationResult
    {
        private readonly Dictionary<string, bool> _features;

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

        public static PfEvaluator Create(IEnumerable<PfFeatureFlag> featureFlags) =>
            new PfEvaluator(new PfInMemoryStore(featureFlags));

        public static PfEvaluator Create(PfStore store) => new PfEvaluator(store);

        public PfEvaluationResult Evaluate(PfUser user)
        {
            var evaluatedFlags = _store.GetFeatureFlags().ToDictionary(x => x.Key, flag => flag.Evaluate(_store, user));
            return new PfEvaluationResult(evaluatedFlags);
        }
    }
}