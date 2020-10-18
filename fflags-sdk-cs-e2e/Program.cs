using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using fflags_sdk_cs;
using fflags_sdk_cs.Evaluator.Values;
using Newtonsoft.Json;

namespace fflags_sdk_cs_e2e
{
    class Program
    {
        private static PfClient _client;

        static void Main(string[] args)
        {
            _client = PfClient.Initialize("52c85313-8203-4963-b984-c5d249320a62", 5);
            var timer = new Timer(PrintData, "auto", 0, 6000);
            Thread.Sleep(100000);
        }

        private static void PrintData(object? state)
        {
            var user = new PfUser("oscar.galindo@csharp.test.com", new Dictionary<string, IPfValue>
            {
                {"country", IPfValue.Create("spain")},
                {"age", IPfValue.Create(18)}
            });

            var single = _client.IsEnabled("someFeature", user);
            var result = _client.EvaluatedFeaturesForUser(user);
            var rc = _client.ValueOf("sap-user", user);
            var nonrc = _client.ValueOf("non-existing-host", user, "defaultValueOfNonExisting");
            Console.WriteLine($"Single Feature {JsonConvert.SerializeObject(single)}");
            Console.WriteLine($"Features {JsonConvert.SerializeObject(result)}");
            Console.WriteLine($"Remote configs {JsonConvert.SerializeObject(rc)}");
            Console.WriteLine($"Default Remote configs {JsonConvert.SerializeObject(nonrc)}");
        }
    }
}