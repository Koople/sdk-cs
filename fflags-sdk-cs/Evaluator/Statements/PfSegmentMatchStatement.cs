using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfSegmentMatchStatement : PfStatement<PfSegmentValue>
    {
        public PfSegmentMatchStatement(IEnumerable<PfSegmentValue> values) : base(null, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return Values
                .Select(value => store.FindSegmentByKey(value.Key()))
                .Any(segment => segment.Evaluate(store, user));
        }
    }
}