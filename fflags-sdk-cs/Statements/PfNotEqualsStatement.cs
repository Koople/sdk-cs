using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfNotEqualsStatement : PfEqualsStatement
    {
        public PfNotEqualsStatement(string attribute, IEnumerable<PfValue<object>> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}