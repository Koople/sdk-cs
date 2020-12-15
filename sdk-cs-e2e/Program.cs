using System;
using System.Threading;
using Koople.Sdk.Evaluator;
using Newtonsoft.Json;

namespace Koople.Sdk.E2E
{
    class Program
    {
        private static KClient _client;

        static void Main(string[] args)
        {
            _client = KClient.Initialize("52c85313-8203-4963-b984-c5d249320a62", 5);
            var timer = new Timer(PrintData, "auto", 0, 6000);
            Thread.Sleep(100000);
        }

        private static void PrintData(object state)
        {
            // var user = new KUser("oscar.galindo@csharp.test.com", new Dictionary<string, IKValue> // Create user if needed
            // {
            //     {"country", IKValue.Create("spain")},
            //     {"age", IKValue.Create(18)}
            // });
            
            var user = KUser.Create("oscar.galindo@csharp.test.com")
                .With("country", "spain")
                .With("age", 18);

            var single = _client.IsEnabled("someFeature", user); // Get feature flag boolean for the user
            var withoutUser = _client.IsEnabled("someFeature"); // Get feature flag boolean without any user (anonymous)
            var result = _client.EvaluatedFeaturesForUser(user); // Get all the feature flags (used mostly for debug)
            var rc = _client.ValueOf("sap-user", user); // Get remote config value for the user
            var nonrc = _client.ValueOf("non-existing-host", user, "defaultValueOfNonExisting"); // Get remote config value for the user with default value
            var anonymous = _client.ValueOf("non-existing-host", "defaultValueOfNonExisting"); // Same methods as above but without user aka DefaultValue of the remote config
            Console.WriteLine($"Single Feature {JsonConvert.SerializeObject(single)}");
            Console.WriteLine($"Features {JsonConvert.SerializeObject(result)}");
            Console.WriteLine($"Remote configs {JsonConvert.SerializeObject(rc)}");
            Console.WriteLine($"Default Remote configs {JsonConvert.SerializeObject(nonrc)}");
        }
    }
}