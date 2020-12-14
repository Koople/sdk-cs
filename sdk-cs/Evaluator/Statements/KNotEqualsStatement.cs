using System.Collections.Generic;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KNotEqualsStatement : KEqualsStatement
    {
        public KNotEqualsStatement(string attribute, IEnumerable<IKValue> values) : base(attribute, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}