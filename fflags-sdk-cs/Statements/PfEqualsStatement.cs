using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfEqualsStatement : PfStatement<PfValue<object>>
    {
        public PfEqualsStatement(string attribute, IEnumerable<PfValue<object>> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetValue(Attribute);
            if (userValue == null) return false;

            return Values.Any(value => userValue.Equals(value));
        }
    }
}