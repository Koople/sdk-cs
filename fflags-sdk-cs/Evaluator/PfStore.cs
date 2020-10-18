using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Evaluator;
using fflags_sdk_cs.Infrastructure;

namespace fflags_sdk_cs
{
    public abstract class PfStore
    {
        public abstract IEnumerable<PfFeatureFlag> GetFeatureFlags();

        public abstract PfSegment FindSegmentByKey(string key);

        public abstract PfFeatureFlag GetFeatureFlag(string feature);

        public abstract PfRemoteConfig GetRemoteConfig(string remoteConfig);
    }

    public class PfInMemoryStore : PfStore
    {
        private readonly Dictionary<string, PfSegment> _segments;
        private readonly Dictionary<string, PfFeatureFlag> _featureFlags;
        private readonly Dictionary<string, PfRemoteConfig> _remoteConfigs;

        public PfInMemoryStore(IEnumerable<PfFeatureFlag> featureFlags, IEnumerable<PfRemoteConfig> remoteConfigs,
            IEnumerable<PfSegment> segments)
        {
            _segments = segments.ToDictionary(s => s.Key);
            _featureFlags = featureFlags.ToDictionary(ff => ff.Key);
            _remoteConfigs = remoteConfigs.ToDictionary(rc => rc.Key);
        }

        public override IEnumerable<PfFeatureFlag> GetFeatureFlags() => _featureFlags.Values;

        public override PfSegment FindSegmentByKey(string key) => _segments[key];
        public override PfFeatureFlag GetFeatureFlag(string feature) => _featureFlags.GetValueOrDefault(feature);
        public override PfRemoteConfig GetRemoteConfig(string remoteConfig) => _remoteConfigs.GetValueOrDefault(remoteConfig);

        public static PfStore FromServer(PfServerInitializeResponseDto dto) =>
            new PfInMemoryStore(dto.Features, dto.RemoteConfigs, dto.Segments);
    }
}