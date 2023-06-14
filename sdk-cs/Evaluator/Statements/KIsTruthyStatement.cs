using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements;

public class KIsTruthyStatement : KStatement<KBooleanValue>
{
    public KIsTruthyStatement(string attribute) : base(attribute, new KBooleanValue[] { })
    {
    }

    public override bool Evaluate(KStore store, KUser user)
    {
        var userValue = user.GetBooleanValue(Attribute);
        if (userValue == null) return false;

        return userValue.IsTruthy();
    }
}