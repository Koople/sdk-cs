using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fflags_sdk_cs;
using fflags_sdk_cs.Evaluator.Values;
using Newtonsoft.Json;

namespace fflags_sdk_cs_e2e
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = await PfClient.Initialize("57062777-61bf-4154-94b7-0457a593de53");
            var user = new PfUser("oscar.galindo@csharp.test.com", new Dictionary<string, IPfValue>
            {
                {"country", IPfValue.Create("spain")},
                {"age", IPfValue.Create(18)}
            });

            var result = client.EvaluatedFeaturesForUser(user);
            var rc = client.ValueOf("api-host", user);
            var nonrc = client.ValueOf("non-existing-host", user, "defaultValueOfNonExisting");
            Console.WriteLine($"Features {JsonConvert.SerializeObject(result)}");
            Console.WriteLine($"Remote configs {JsonConvert.SerializeObject(rc)}");
            Console.WriteLine($"Default Remote configs {JsonConvert.SerializeObject(nonrc)}");
        }
    }
}