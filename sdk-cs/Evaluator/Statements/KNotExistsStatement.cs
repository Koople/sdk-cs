using System.Collections.Generic;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements;

public class KNotExistsStatement : KExistsStatement
{
    public KNotExistsStatement(string attribute, IEnumerable<IKValue> values) : base(attribute, values)
    {
    }

    public override bool Evaluate(KStore store, KUser user)
    {
        return !base.Evaluate(store, user);
    }
}