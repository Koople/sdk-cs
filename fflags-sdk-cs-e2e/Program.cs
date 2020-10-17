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
            var client = await PfClient.Initialize("a35f79d1-8a68-4d5b-a49c-d23fd130131d");
            var user = new PfUser("oscar.galindo@csharp.test.com", new Dictionary<string, IPfValue>
            {
                {"country", IPfValue.Create("spain")},
                {"age", IPfValue.Create(18)}
            });

            var result = client.EvaluatedFeaturesForUser(user);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}