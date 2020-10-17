namespace fflags_sdk_cs
{
    public interface IPfEvaluable
    {
        public bool Evaluate(PfStore store, PfUser user);
    }
}