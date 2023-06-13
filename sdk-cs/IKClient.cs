using Koople.Sdk.Evaluator;

namespace Koople.Sdk
{
    public interface IKClient
    {
        bool IsEnabled(string feature, KUser user);
        bool IsEnabled(string feature);
        KEvaluationResult EvaluatedFeaturesForUser(KUser user);
        string ValueOf(string remoteConfig, KUser user, string defaultValue = "");
        string ValueOf(string remoteConfig, string defaultValue = "");
    }
}