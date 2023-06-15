using System.Collections.Generic;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator;

public abstract class KStatement<T> : IKEvaluable
    where T : IKValue
{
    protected string Attribute { get; }
    protected IEnumerable<T> Values { get; }

    protected KStatement(string attribute, IEnumerable<T> values)
    {
        Attribute = attribute;
        Values = values;
    }

    public abstract bool Evaluate(KStore store, KUser user);
}