using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfNotSegmentMatchStatement : PfSegmentMatchStatement
    {
        public PfNotSegmentMatchStatement(IEnumerable<PfSegmentValue> values) : base(values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}