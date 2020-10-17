using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Evaluator.Statements
{
    public class PfGreaterThanOrEqualsStatement : PfStatement<PfNumberValue>
    {
        public PfGreaterThanOrEqualsStatement(string attribute, IEnumerable<PfNumberValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetNumberValue(Attribute);
            if (userValue == null) return false;

            return userValue.GreaterThanOrEquals(Values.First());
        }
    }
}