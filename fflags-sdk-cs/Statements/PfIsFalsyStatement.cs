namespace fflags_sdk_cs.Statements
{
    public class PfIsFalsyStatement : PfIsTruthyStatement
    {
        public PfIsFalsyStatement(string attribute) : base(attribute)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}