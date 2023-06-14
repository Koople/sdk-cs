using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements;

public class KEqualsStatement : KStatement<IKValue>
{
    public KEqualsStatement(string attribute, IEnumerable<IKValue> values) : base(attribute, values)
    {
    }

    public override bool Evaluate(KStore store, KUser user)
    {
        var userValue = user.GetValue(Attribute);
        if (userValue == null) return false;

        return Values.Any(value => userValue.IsEquals(value));
    }
}