using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfExistsStatement : PfStatement<PfValue<object>>
    {
        public PfExistsStatement(string attribute, IEnumerable<PfValue<object>> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetValue(Attribute);
            return userValue != null && userValue.ToString() != null && userValue.ToString() != "";
        }
    }
}