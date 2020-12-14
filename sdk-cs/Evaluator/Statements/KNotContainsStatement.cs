using System.Collections.Generic;
using Koople.Sdk.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KNotContainsStatement : KContainsStatement
    {
        public KNotContainsStatement(string attribute, IEnumerable<KStringValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}