using System.Collections.Generic;
using System.Linq;

namespace Koople.Sdk.Evaluator.Rules;

public class KSegmentRule
{
    public readonly int Order;
    public readonly IEnumerable<IKEvaluable> Statements;

    public KSegmentRule(int order, IEnumerable<IKEvaluable> statements)
    {
        Order = order;
        Statements = statements;
    }

    public bool Evaluate(KStore store, KUser user)
    {
        return Statements.All(statement => statement.Evaluate(store, user));
    }
}