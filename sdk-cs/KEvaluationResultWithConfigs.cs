using System.Collections.Generic;

namespace Koople.Sdk;

public class KEvaluationResultWithConfigs
{
    public Dictionary<string, bool> FeatureFlags { get; set; }
    public Dictionary<string, string> RemoteConfigs { get; set; }
}

public class KFeaturesAndConfigs
{
    public KEvaluationResultWithConfigs Evaluation { get; set; }

    public KFeaturesAndConfigs(Dictionary<string, bool> features, Dictionary<string, string> configs)
    {
        Evaluation = new KEvaluationResultWithConfigs()
        {
            FeatureFlags = features,
            RemoteConfigs = configs
        };
    }
}