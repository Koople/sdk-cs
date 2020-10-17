using fflags_sdk_cs.Evaluator.Statements;
using fflags_sdk_cs.Statements;
using JsonSubTypes;
using Newtonsoft.Json;

namespace fflags_sdk_cs.Evaluator
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfEqualsStatement), "equals")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfNotEqualsStatement), "notEquals")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfExistsStatement), "exists")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfNotExistsStatement), "notExists")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfContainsStatement), "contains")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfNotContainsStatement), "notContains")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfGreaterThanStatement), "greaterThan")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfGreaterThanOrEqualsStatement), "greaterThanOrEquals")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfLessThanStatement), "lessThan")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfLessThanOrEqualsStatement), "lessThanOrEquals")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfIsTruthyStatement), "isTruthy")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfIsFalsyStatement), "isFalsy")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfSegmentMatchStatement), "segmentMatch")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfSegmentNotMatchStatement), "segmentNotMatch")]
    public interface IPfEvaluable
    {
        public bool Evaluate(PfStore store, PfUser user);
    }
}