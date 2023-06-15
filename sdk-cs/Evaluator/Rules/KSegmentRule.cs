using System.Collections.Generic;
using System.Linq;

namespace Koople.Sdk.Evaluator.Rules;

public class KSegmentRule
{
    public int Order { get; }
    public IEnumerable<IKEvaluable> Statements { get; }

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