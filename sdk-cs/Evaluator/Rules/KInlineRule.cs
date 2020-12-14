using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator;

namespace Koople.Sdk
{
    public class KInlineRule
    {
        public readonly int Order;
        public readonly IEnumerable<IKEvaluable> Statements;

        public KInlineRule(int order, IEnumerable<IKEvaluable> statements)
        {
            Order = order;
            Statements = statements;
        }

        // TODO: Test
        public bool Evaluate(KStore store, KUser user) =>
            Statements.All(statement => statement.Evaluate(store, user));
    }
}