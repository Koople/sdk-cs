using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfNotContainsStatement : PfContainsStatement
    {
        public PfNotContainsStatement(string attribute, IEnumerable<PfStringValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}