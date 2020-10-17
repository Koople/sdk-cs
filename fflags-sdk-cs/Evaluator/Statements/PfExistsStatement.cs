using System.Collections.Generic;
using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfExistsStatement : PfStatement<IPfValue>
    {
        public PfExistsStatement(string attribute, IEnumerable<IPfValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetValue(Attribute);
            return userValue != null && userValue.ToString() != null && userValue.ToString() != "";
        }
    }
}