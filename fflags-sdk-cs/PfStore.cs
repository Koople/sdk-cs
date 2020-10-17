using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public abstract class PfStore
    {
        public abstract IEnumerable<PfFeatureFlag> GetFeatureFlags();

        public abstract PfSegment FindSegmentByKey(string key);
    }

    public class PfInMemoryStore : PfStore
    {
        private readonly Dictionary<string, PfSegment> _segments;
        private Dictionary<string, PfFeatureFlag> _featureFlags;

        public PfInMemoryStore(IEnumerable<PfFeatureFlag> featureFlags, IEnumerable<PfSegment> segments)
        {
            _segments = segments.ToDictionary(s => s.Key);
            _featureFlags = featureFlags.ToDictionary(ff => ff.Key);
        }

        public override IEnumerable<PfFeatureFlag> GetFeatureFlags() => _featureFlags.Values;

        public override PfSegment FindSegmentByKey(string key) => _segments[key];
    }
}