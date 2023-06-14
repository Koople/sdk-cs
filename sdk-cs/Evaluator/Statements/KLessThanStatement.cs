using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements;

public class KLessThanStatement : KStatement<KNumberValue>
{
    public KLessThanStatement(string attribute, IEnumerable<KNumberValue> values) : base(attribute, values)
    {
    }

    public override bool Evaluate(KStore store, KUser user)
    {
        var userValue = user.GetNumberValue(Attribute);
        if (userValue == null) return false;

        return userValue.LessThan(Values.First());
    }
}