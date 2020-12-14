using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KGreaterThanOrEqualsStatement : KStatement<KNumberValue>
    {
        public KGreaterThanOrEqualsStatement(string attribute, IEnumerable<KNumberValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            var userValue = user.GetNumberValue(Attribute);
            if (userValue == null) return false;

            return userValue.GreaterThanOrEquals(Values.First());
        }
    }
}