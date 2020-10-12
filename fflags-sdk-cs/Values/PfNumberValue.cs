namespace fflags_sdk_cs.Values
{
    public class PfNumberValue : PfValue<int>
    {
        public PfNumberValue(int value) : base(value)
        {
        }

        public bool GreaterThan(PfNumberValue other) {
            return Value > other.Value;
        }

        public bool GreaterThanOrEquals(PfNumberValue other) {
            return Value >= other.Value;
        }

        public bool LessThan(PfNumberValue other) {
            return Value < other.Value;
        }

        public bool LessThanOrEquals(PfNumberValue other) {
            return Value <= other.Value;
        }

        public bool Equals(PfNumberValue other) {
            return Value == other.Value;
        }

        public bool NotEquals(PfNumberValue other)
        {
            return !Equals(other);
        }
    }
}