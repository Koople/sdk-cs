namespace fflags_sdk_cs.Values
{
    public class PfNumberValue : PfValue<int>
    {
        public PfNumberValue(int value) : base(value)
        {
        }

        public bool GreaterThan(PfNumberValue other) {
            return _value > other._value;
        }

        public bool GreaterThanOrEquals(PfNumberValue other) {
            return _value >= other._value;
        }

        public bool LessThan(PfNumberValue other) {
            return _value < other._value;
        }

        public bool LessThanOrEquals(PfNumberValue other) {
            return _value <= other._value;
        }

        public bool Equals(PfNumberValue other) {
            return _value == other._value;
        }

        public bool NotEquals(PfNumberValue other)
        {
            return !Equals(other);
        }
    }
}