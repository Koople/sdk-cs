using System;

namespace fflags_sdk_cs.Values
{
    public interface IPfValue
    {
        bool IsEquals(IPfValue other);
        bool NotEquals(IPfValue other);

        object GetValue();

        PfStringValue AsString();
        PfNumberValue AsNumber();
        PfBooleanValue AsBoolean();
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

        public object GetValue() => Value;

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

        public bool IsEquals(IPfValue other) => GetType() == other.GetType() && Value.Equals(other.GetValue());

        public bool NotEquals(IPfValue other) => !Equals(other);

        public static IPfValue Create(object value) => value switch
        {
            bool boolValue => new PfBooleanValue(boolValue),
            string stringValue => new PfStringValue(stringValue),
            int intValue => new PfNumberValue(intValue),
            _ => throw new UserAttributeTypeNotSupportedException()
        };
    }
}