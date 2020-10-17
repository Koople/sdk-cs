using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Evaluator;

namespace fflags_sdk_cs
{
    public class PfInlineRule
    {
        public readonly int Order;
        public readonly IEnumerable<IPfEvaluable> Statements;

        public PfInlineRule(int order, IEnumerable<IPfEvaluable> statements)
        {
            Order = order;
            Statements = statements;
        }

        // TODO: Test
        public bool Evaluate(PfStore store, PfUser user) =>
            Statements.All(statement => statement.Evaluate(store, user));
    }
}