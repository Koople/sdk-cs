using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Values
{
    public class KStringValue : KValue<string>
    {
        public KStringValue(string value) : base(value)
        {
        }

        public bool IsEmpty() {
            return string.IsNullOrEmpty(Value.Trim());
        }

        public bool IsNotEmpty() {
            return !IsEmpty();
        }

        public bool Contains(KStringValue other)
        {
            return Value.Contains(other.Value);
        }

        public bool Equals(KStringValue other) {
            return Value == other.Value;
        }

        public bool NotEquals(KStringValue other)
        {
            return !Equals(other);
        }
    }
}