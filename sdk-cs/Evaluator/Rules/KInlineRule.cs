using System.Collections.Generic;
using System.Linq;

namespace Koople.Sdk.Evaluator.Rules;

public class KInlineRule
{
    public int Order { get; }
    public IEnumerable<IKEvaluable> Statements { get; }

    public KInlineRule(int order, IEnumerable<IKEvaluable> statements)
    {
        Order = order;
        Statements = statements;
    }

    // TODO: Test
    public bool Evaluate(KStore store, KUser user) =>
        Statements.All(statement => statement.Evaluate(store, user));
}