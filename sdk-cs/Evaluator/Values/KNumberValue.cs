using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Values
{
    public class KNumberValue : KValue<int>
    {
        public KNumberValue(int value) : base(value)
        {
        }

        public bool GreaterThan(KNumberValue other) {
            return Value > other.Value;
        }

        public bool GreaterThanOrEquals(KNumberValue other) {
            return Value >= other.Value;
        }

        public bool LessThan(KNumberValue other) {
            return Value < other.Value;
        }

        public bool LessThanOrEquals(KNumberValue other) {
            return Value <= other.Value;
        }

        public bool Equals(KNumberValue other) {
            return Value == other.Value;
        }

        public bool NotEquals(KNumberValue other)
        {
            return !Equals(other);
        }
    }
}