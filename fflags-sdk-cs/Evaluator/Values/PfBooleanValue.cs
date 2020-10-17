using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Values
{
    public class PfBooleanValue : PfValue<bool>
    {
        public PfBooleanValue(bool value) : base(value)
        {
        }
        
        public static PfBooleanValue True() {
            return new PfBooleanValue(true);
        }

        public static PfBooleanValue False() {
            return new PfBooleanValue(false);
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