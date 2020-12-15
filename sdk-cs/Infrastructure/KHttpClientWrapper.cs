using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Koople.Sdk.Evaluator;
using Newtonsoft.Json;

namespace Koople.Sdk.Infrastructure
{
    public class KServerInitializeResponseDto
    {
        public IEnumerable<KFeatureFlag> Features { get; set; }
        public IEnumerable<KSegment> Segments { get; set; }
        public IEnumerable<KRemoteConfig> RemoteConfigs { get; set; }
    }

    public class KHttpClientWrapper
    {
        private static readonly Uri SdkApiUrl = new Uri("https://sdk.pataflags.com/proxy/server/initialize");

        private readonly HttpClient _httpClient;

        public KHttpClientWrapper()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = SdkApiUrl
            };
        }

        public async Task<T> Get<T>(KHttpRequest httpRequest)
        {
            var request = new HttpRequestMessage
            {
                Headers =
                {
                    {"x-api-key", httpRequest.GetApiKey()}
                },
                Method = HttpMethod.Get,
                RequestUri = SdkApiUrl
            };
            var body = _httpClient.SendAsync(request);
            var jsonResponse = await body.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}