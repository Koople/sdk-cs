using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs.Statements
{
    public class PfIsTruthyStatement : PfStatement<PfBooleanValue>
    {
        public PfIsTruthyStatement(string attribute) : base(attribute, new PfBooleanValue[] { })
        {
        }

        public override bool Evaluate(PfStore store, PfUser user)
        {
            var userValue = user.GetBooleanValue(Attribute);
            if (userValue == null) return false;

            return userValue.IsTruthy();
        }
    }
}