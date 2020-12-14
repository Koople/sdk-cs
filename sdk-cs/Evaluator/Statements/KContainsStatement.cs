using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KContainsStatement : KStatement<KStringValue>
    {
        public KContainsStatement(string attribute, IEnumerable<KStringValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            var userValue = user.GetStringValue(Attribute);
            if (userValue == null) return false;

            return Values.Any(value => userValue.Contains(value));
        }
    }
}