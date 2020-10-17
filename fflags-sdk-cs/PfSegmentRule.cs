using System.Collections.Generic;
using System.Linq;

namespace fflags_sdk_cs
{
    public class PfSegmentRule
    {
        public readonly int Order;
        public readonly IEnumerable<IPfEvaluable> Statements;

        public PfSegmentRule(int order, IEnumerable<IPfEvaluable> statements)
        {
            Order = order;
            Statements = statements;
        }

        public bool Evaluate(PfStore store, PfUser user)
        {
            return Statements.All(statement => statement.Evaluate(store, user));
        }
    }
}