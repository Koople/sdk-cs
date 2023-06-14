using JsonSubTypes;
using Koople.Sdk.Evaluator.Statements;
using Newtonsoft.Json;

namespace Koople.Sdk.Evaluator;

[JsonConverter(typeof(JsonSubtypes), "type")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KEqualsStatement), "equals")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KNotEqualsStatement), "notEquals")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KExistsStatement), "exists")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KNotExistsStatement), "notExists")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KContainsStatement), "contains")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KNotContainsStatement), "notContains")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KGreaterThanStatement), "greaterThan")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KGreaterThanOrEqualsStatement), "greaterThanOrEquals")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KLessThanStatement), "lessThan")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KLessThanOrEqualsStatement), "lessThanOrEquals")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KIsTruthyStatement), "isTruthy")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KIsFalsyStatement), "isFalsy")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KSegmentMatchStatement), "segmentMatch")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KSegmentNotMatchStatement), "segmentNotMatch")]
public interface IKEvaluable
{
    bool Evaluate(KStore store, KUser user);
}