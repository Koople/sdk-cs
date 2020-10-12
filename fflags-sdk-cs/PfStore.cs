using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public abstract class PfStore
    {
        public abstract IEnumerable<PfFeatureFlag> GetFeatureFlags();
        // private Dictionary<string, PFRemoteConfig> remoteConfigs;
        // private Dictionary<string, PFSegment> segments;
    }

    public class PfInMemoryStore : PfStore
    {
        private Dictionary<string, PfFeatureFlag> _featureFlags;

        public PfInMemoryStore(IEnumerable<PfFeatureFlag> featureFlags)
        {
            _featureFlags = featureFlags.ToDictionary(ff => ff.Key);
        }

        public override IEnumerable<PfFeatureFlag> GetFeatureFlags() => _featureFlags.Values;
    }
}