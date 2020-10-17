using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class LessThanOrEquals : PfStatement<PfNumberValue>
    {
        public LessThanOrEquals(string attribute, IEnumerable<PfNumberValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetNumberValue(Attribute);
            if (userValue == null) return false;

            return userValue.LessThanOrEquals(Values.First());
        }
    }
}