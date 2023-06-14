using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Infrastructure;

namespace Koople.Sdk.Evaluator;

public abstract class KStore
{
    public abstract IEnumerable<KFeatureFlag> GetFeatureFlags();

    public abstract KSegment FindSegmentByKey(string key);

    public abstract KFeatureFlag GetFeatureFlag(string feature);

    public abstract KRemoteConfig GetRemoteConfig(string remoteConfig);

    public abstract KStore Initial();
    public abstract KStore FromServer(KServerInitializeResponseDto dto);
}

public class KInMemoryStore : KStore
{
    private readonly Dictionary<string, KSegment> _segments;
    private readonly Dictionary<string, KFeatureFlag> _featureFlags;
    private readonly Dictionary<string, KRemoteConfig> _remoteConfigs;

    public KInMemoryStore(){}
    public KInMemoryStore(IEnumerable<KFeatureFlag> featureFlags, IEnumerable<KRemoteConfig> remoteConfigs,
        IEnumerable<KSegment> segments)
    {
        _segments = segments.ToDictionary(s => s.Key);
        _featureFlags = featureFlags.ToDictionary(ff => ff.Key);
        _remoteConfigs = remoteConfigs.ToDictionary(rc => rc.Key);
    }
    

    public override IEnumerable<KFeatureFlag> GetFeatureFlags() => _featureFlags.Values;

    public override KSegment FindSegmentByKey(string key) => _segments[key];
    public override KFeatureFlag GetFeatureFlag(string feature) => _featureFlags.GetValueOrDefault(feature);
    public override KRemoteConfig GetRemoteConfig(string remoteConfig) => _remoteConfigs.GetValueOrDefault(remoteConfig);

    public override KStore FromServer(KServerInitializeResponseDto dto) =>
        new KInMemoryStore(dto.Features, dto.RemoteConfigs, dto.Segments);
    public override KStore Initial() => new KInMemoryStore(new KFeatureFlag[] { }, new KRemoteConfig[] { }, new KSegment[] { });
}