using System;
using fflags_sdk_cs.Values;
using JsonSubTypes;
using Newtonsoft.Json;

namespace fflags_sdk_cs.Evaluator.Values
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfStringValue), "string")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfNumberValue), "number")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PfSegmentValue), "segment")]
    public abstract class IPfValue
    {
        public abstract bool IsEquals(IPfValue other);
        public abstract bool NotEquals(IPfValue other);

        public abstract object GetValue();

        public abstract PfStringValue AsString();
        public abstract PfNumberValue AsNumber();
        public abstract PfBooleanValue AsBoolean();

        public static IPfValue Create(object value)
        {
            switch (value)
            {
                case bool boolValue:
                    return new PfBooleanValue(boolValue);
                case string stringValue:
                    return new PfStringValue(stringValue);
                case int intValue:
                    return new PfNumberValue(intValue);
                default:
                    throw new UserAttributeTypeNotSupportedException();
            }
        }
    }

    public class UserAttributeTypeNotSupportedException : Exception
    {
    }

    public abstract class PfValue<T> : IPfValue
    {
        protected readonly T Value;

        protected PfValue(T value)
        {
            Value = value;
        }

        public override object GetValue() => Value;

        public override PfStringValue AsString()
        {
            if (GetType() == typeof(PfStringValue))
                return this as PfStringValue;

            return null;
        }

        public override PfNumberValue AsNumber()
        {
            if (GetType() == typeof(PfNumberValue))
                return this as PfNumberValue;

            return null;
        }

        public override PfBooleanValue AsBoolean()
        {
            if (GetType() == typeof(PfBooleanValue))
                return this as PfBooleanValue;

            return null;
        }

        public override bool IsEquals(IPfValue other) => GetType() == other.GetType() && Value.Equals(other.GetValue());

        public override bool NotEquals(IPfValue other) => !Equals(other);
    }
}