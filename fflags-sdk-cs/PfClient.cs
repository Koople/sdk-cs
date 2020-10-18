using System;
using System.Threading.Tasks;
using fflags_sdk_cs.Infrastructure;

namespace fflags_sdk_cs
{
    public class PfClient
    {
        private readonly PfStore _store;
        private PfEvaluator _evaluator;

        private PfClient(PfStore store)
        {
            _store = store;
            _evaluator = PfEvaluator.Create(store);
        }

        public bool IsEnabled(string feature, PfUser user)
        {
            return _evaluator.Evaluate(feature, user);
        }

        public PfEvaluationResult EvaluatedFeaturesForUser(PfUser user)
        {
            return _evaluator.Evaluate(user);
        }

        public string ValueOf(string remoteConfig, PfUser user, string defaultValue = "")
        {
            return _evaluator.ValueOf(remoteConfig, user, defaultValue);
        }

        public static async Task<PfClient> Initialize(string apiKey)
        {
            var initializeRequest = new PfHttpRequest(apiKey);
            var httpClient = new PfHttpClientWrapper();
            var serverInitResponse = await httpClient.Get<PfServerInitializeResponseDto>(initializeRequest);
            var store = PfInMemoryStore.FromServer(serverInitResponse);
            return new PfClient(store);
        }
    }
}