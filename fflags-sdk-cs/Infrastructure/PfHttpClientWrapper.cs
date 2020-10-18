using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using fflags_sdk_cs.Evaluator;
using Newtonsoft.Json;

namespace fflags_sdk_cs.Infrastructure
{
    public class PfServerInitializeResponseDto
    {
        public IEnumerable<PfFeatureFlag> Features { get; set; }
        public IEnumerable<PfSegment> Segments { get; set; }
        public IEnumerable<PfRemoteConfig> RemoteConfigs { get; set; }
    }

    public class PfHttpClientWrapper
    {
        private static readonly Uri SdkApiUrl = new Uri("https://sdk.pataflags.com/proxy/server/initialize");

        private HttpClient _httpClient;

        public PfHttpClientWrapper()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = SdkApiUrl
            };
        }

        public async Task<T> Get<T>(PfHttpRequest httpRequest)
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