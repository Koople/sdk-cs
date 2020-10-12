using System;

namespace fflags_sdk_cs.Values
{
    public class PfStringValue : PfValue<string>
    {
        public PfStringValue(string value) : base(value)
        {
        }

        public bool IsEmpty() {
            return string.IsNullOrEmpty(_value.Trim());
        }

        public bool IsNotEmpty() {
            return !IsEmpty();
        }

        public bool Contains(PfStringValue other)
        {
            return _value.Contains(other._value);
        }

        public bool Equals(PfStringValue other) {
            return _value == other._value;
        }

        public bool NotEquals(PfStringValue other)
        {
            return !Equals(other);
        }
    }
}