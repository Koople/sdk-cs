using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator;

namespace Koople.Sdk
{
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
}