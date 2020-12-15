namespace Koople.Sdk.Evaluator.Statements
{
    public class KIsFalsyStatement : KIsTruthyStatement
    {
        public KIsFalsyStatement(string attribute) : base(attribute)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}