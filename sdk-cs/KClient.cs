using System;
using System.Data;
using System.Threading;
using Koople.Sdk.Evaluator;
using Koople.Sdk.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Koople.Sdk;

public class KClientService : IDisposable
{
    private readonly string _apiKey;
    private readonly ILogger<KClientService> _logger;
    private readonly Timer _timer;
    private KEvaluator _evaluator;

    public KClientService(string apiKey, int pollingInterval = 60) 
        : this(apiKey, new KInMemoryStore(), pollingInterval){}

    public KClientService(string apiKey, KStore store, int pollingInterval = 60, ILogger<KClientService>? logger = null)
    {
        _apiKey = apiKey;
        _logger = logger;
        _timer = new Timer(FetchStore, null, TimeSpan.Zero, TimeSpan.FromSeconds(pollingInterval));
        _evaluator = KEvaluator.Create(store.Initial());
    }

    private async void FetchStore(object state)
    {
        try
        {
            var initializeRequest = new KHttpRequest(_apiKey);
            var httpClient = new KHttpClientWrapper();
            var serverInitResponse = await httpClient.Get<KServerInitializeResponseDto>(initializeRequest);
            _evaluator = _evaluator.FromServer(serverInitResponse);    
        }
        catch (Exception e)
        {
            _logger?.LogError($"{e.Message} {e.StackTrace}");
        }
    }

    public KEvaluationResult EvaluatedFeaturesForUser(KUser user) => _evaluator.Evaluate(user);

    public bool IsEnabled(string feature, KUser user) => _evaluator.Evaluate(feature, user);
    public bool IsEnabled(string feature) => _evaluator.Evaluate(feature, KUser.Anonymous());
    
    public KFeaturesAndConfigs GetAllResults(KUser user) => _evaluator.GetAllResultsForUser(user);

    public string ValueOf(string remoteConfig, KUser user, string defaultValue) =>
        _evaluator.ValueOf(remoteConfig, user, defaultValue);
        
    public string ValueOf(string remoteConfig, string defaultValue) =>
        _evaluator.ValueOf(remoteConfig, KUser.Anonymous(), defaultValue);

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
public class KClient : IKClient
{
    private readonly KClientService _clientService;

    private KClient(KClientService clientService)
    {
        _clientService = clientService;
    }

    public bool IsEnabled(string feature, KUser user) => _clientService.IsEnabled(feature, user);
        
    public bool IsEnabled(string feature) => _clientService.IsEnabled(feature);

    public KEvaluationResult EvaluatedFeaturesForUser(KUser user) =>
        _clientService.EvaluatedFeaturesForUser(user);
    
    

    public string ValueOf(string remoteConfig, KUser user, string defaultValue = "") =>
        _clientService.ValueOf(remoteConfig, user, defaultValue);
        
    public string ValueOf(string remoteConfig, string defaultValue = "") =>
        _clientService.ValueOf(remoteConfig, defaultValue);

    public static KClient Initialize(string apiKey, int pollingInterval = 60)
        => Initialize(apiKey, new KInMemoryStore(), pollingInterval);

    public static KClient Initialize(string apiKey, KStore store, int pollingInterval = 60, ILoggerFactory? loggerFactory = null)
    {
        if(string.IsNullOrEmpty(apiKey)) throw new NoNullAllowedException("ApiKey can not be null or empty");
        var service = new KClientService(apiKey, store, pollingInterval, loggerFactory?.CreateLogger<KClientService>());
        return new KClient(service);
    }
}