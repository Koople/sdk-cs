using System;

namespace Koople.Sdk
{
    public class KHttpRequest
    {
        private readonly string _apiKey;

        public KHttpRequest(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string GetApiKey()
        {
            return _apiKey;
        }
    }
}