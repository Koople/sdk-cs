using System;
using System.Threading;
using fflags_sdk_cs.Evaluator;
using fflags_sdk_cs.Infrastructure;

namespace fflags_sdk_cs
{
    public class PfClientService : IDisposable
    {
        private readonly string _apiKey;
        private readonly Timer _timer;
        private PfEvaluator _evaluator;

        public PfClientService(string apiKey, int pollingInterval = 60)
        {
            _apiKey = apiKey;
            _timer = new Timer(FetchStore, null, TimeSpan.Zero, TimeSpan.FromSeconds(pollingInterval));
            _evaluator = PfEvaluator.Create(PfInMemoryStore.Empty());
        }

        private async void FetchStore(object state)
        {
            var initializeRequest = new PfHttpRequest(_apiKey);
            var httpClient = new PfHttpClientWrapper();
            var serverInitResponse = await httpClient.Get<PfServerInitializeResponseDto>(initializeRequest);
            _evaluator = PfEvaluator.Create(PfInMemoryStore.FromServer(serverInitResponse));
        }

        public PfEvaluationResult EvaluatedFeaturesForUser(PfUser user) => _evaluator.Evaluate(user);

        public bool IsEnabled(string feature, PfUser user) => _evaluator.Evaluate(feature, user);
        public bool IsEnabled(string feature) => _evaluator.Evaluate(feature, PfUser.Anonymous());

        public string ValueOf(string remoteConfig, PfUser user, string defaultValue) =>
            _evaluator.ValueOf(remoteConfig, user, defaultValue);
        
        public string ValueOf(string remoteConfig, string defaultValue) =>
            _evaluator.ValueOf(remoteConfig, PfUser.Anonymous(), defaultValue);

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

    public class PfClient
    {
        private readonly PfClientService _clientService;

        private PfClient(PfClientService clientService)
        {
            _clientService = clientService;
        }

        public bool IsEnabled(string feature, PfUser user) => _clientService.IsEnabled(feature, user);
        
        public bool IsEnabled(string feature) => _clientService.IsEnabled(feature);

        public PfEvaluationResult EvaluatedFeaturesForUser(PfUser user) =>
            _clientService.EvaluatedFeaturesForUser(user);

        public string ValueOf(string remoteConfig, PfUser user, string defaultValue = "") =>
            _clientService.ValueOf(remoteConfig, user, defaultValue);
        
        public string ValueOf(string remoteConfig, string defaultValue = "") =>
            _clientService.ValueOf(remoteConfig, defaultValue);

        public static PfClient Initialize(string apiKey, int pollingInterval = 60)
        {
            var service = new PfClientService(apiKey, pollingInterval);
            return new PfClient(service);
        }
    }
}