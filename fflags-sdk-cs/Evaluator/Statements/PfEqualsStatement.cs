using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfEqualsStatement : PfStatement<IPfValue>
    {
        public PfEqualsStatement(string attribute, IEnumerable<IPfValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetValue(Attribute);
            if (userValue == null) return false;

            return Values.Any(value => userValue.IsEquals(value));
        }
    }
}