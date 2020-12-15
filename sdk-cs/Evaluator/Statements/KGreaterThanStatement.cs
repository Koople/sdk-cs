using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KGreaterThanStatement : KStatement<KNumberValue>
    {
        public KGreaterThanStatement(string attribute, IEnumerable<KNumberValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            var userValue = user.GetNumberValue(Attribute);
            if (userValue == null) return false;

            return userValue.GreaterThan(Values.First());
        }
    }
}