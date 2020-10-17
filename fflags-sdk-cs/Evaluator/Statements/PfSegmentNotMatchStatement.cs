using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfSegmentNotMatchStatement : PfSegmentMatchStatement
    {
        public PfSegmentNotMatchStatement(IEnumerable<PfSegmentValue> values) : base(values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}