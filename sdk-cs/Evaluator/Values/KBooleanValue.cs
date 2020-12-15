namespace Koople.Sdk.Evaluator.Values
{
    public class KBooleanValue : KValue<bool>
    {
        public KBooleanValue(bool value) : base(value)
        {
        }
        
        public static KBooleanValue True() {
            return new KBooleanValue(true);
        }

        public static KBooleanValue False() {
            return new KBooleanValue(false);
        }

        public bool IsTruthy()
        {
            return Value;
        }

        public bool IsFalsy()
        {
            return !Value;
        }
    }
}