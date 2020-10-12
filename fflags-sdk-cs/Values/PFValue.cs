using System;

namespace fflags_sdk_cs.Values
{
    public interface IPfValue
    {
    }
    
    public class UserAttributeTypeNotSupportedException : Exception {}
    
    public abstract class PfValue<T> : IPfValue
    {
        protected readonly T _value;

        public PfValue(T value)
        {
            _value = value;
        }
        
        public static IPfValue Create(object value)
        {
            return value switch
            {
                bool boolValue => new PfBooleanValue(boolValue),
                string stringValue => new PfStringValue(stringValue),
                int intValue => new PfNumberValue(intValue),
                _ => throw new UserAttributeTypeNotSupportedException()
            };
        }
    }
}