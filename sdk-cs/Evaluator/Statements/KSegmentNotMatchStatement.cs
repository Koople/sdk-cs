using System.Collections.Generic;
using Koople.Sdk.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KSegmentNotMatchStatement : KSegmentMatchStatement
    {
        public KSegmentNotMatchStatement(IEnumerable<KSegmentValue> values) : base(values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            return !base.Evaluate(store, user);
        }
    }
}