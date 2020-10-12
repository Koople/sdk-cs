using System;

namespace fflags_sdk_cs.Values
{
    public interface IPfValue
    {
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

        public PfStringValue AsString()
        {
            if (GetType() == typeof(PfStringValue))
                return this as PfStringValue;

            return null;
        }

        public PfNumberValue AsNumber()
        {
            if (GetType() == typeof(PfNumberValue))
                return this as PfNumberValue;

            return null;
        }

        public PfBooleanValue AsBoolean()
        {
            if (GetType() == typeof(PfBooleanValue))
                return this as PfBooleanValue;

            return null;
        }

        public bool Equals(PfValue<object> other) => GetType() == other.GetType() && Value.Equals(other.Value);

        public bool NotEquals(PfValue<object> other) => !Equals(other);

        public static IPfValue Create(object value) => value switch
        {
            bool boolValue => new PfBooleanValue(boolValue),
            string stringValue => new PfStringValue(stringValue),
            int intValue => new PfNumberValue(intValue),
            _ => throw new UserAttributeTypeNotSupportedException()
        };
    }
}