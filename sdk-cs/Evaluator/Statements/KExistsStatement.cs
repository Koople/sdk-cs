using System.Collections.Generic;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements;

public class KExistsStatement : KStatement<IKValue>
{
    public KExistsStatement(string attribute, IEnumerable<IKValue> values) : base(attribute, values)
    {
    }

    public override bool Evaluate(KStore store, KUser user)
    {
        var userValue = user.GetValue(Attribute);
        return userValue != null && userValue.ToString() != null && userValue.ToString() != "";
    }
}