using System.Collections.Generic;
using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfNotExistsStatement : PfExistsStatement
    {
        public PfNotExistsStatement(string attribute, IEnumerable<IPfValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}