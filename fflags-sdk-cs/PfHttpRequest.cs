using System;

namespace fflags_sdk_cs
{
    public class PfHttpRequest
    {
        private readonly string _apiKey;

        public PfHttpRequest(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string GetApiKey()
        {
            return _apiKey;
        }
    }
}