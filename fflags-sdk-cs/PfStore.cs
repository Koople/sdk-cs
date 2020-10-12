using System.Collections.Generic;

namespace fflags_sdk_cs
{
    public class PfStore
    {
        private Dictionary<string, PFFeatureFlag> featureFlags;
        private Dictionary<string, PFRemoteConfig> remoteConfigs;
        private Dictionary<string, PFSegment> segments;
    }
}