using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Values
{
    public class PfStringValue : PfValue<string>
    {
        public PfStringValue(string value) : base(value)
        {
        }

        public bool IsEmpty() {
            return string.IsNullOrEmpty(Value.Trim());
        }

        public bool IsNotEmpty() {
            return !IsEmpty();
        }

        public bool Contains(PfStringValue other)
        {
            return Value.Contains(other.Value);
        }

        public bool Equals(PfStringValue other) {
            return Value == other.Value;
        }

        public bool NotEquals(PfStringValue other)
        {
            return !Equals(other);
        }
    }
}