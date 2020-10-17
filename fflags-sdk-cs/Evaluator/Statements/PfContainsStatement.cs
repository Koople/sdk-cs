using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfContainsStatement : PfStatement<PfStringValue>
    {
        public PfContainsStatement(string attribute, IEnumerable<PfStringValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetStringValue(Attribute);
            if (userValue == null) return false;

            return Values.Any(value => userValue.Contains(value));
        }
    }
}