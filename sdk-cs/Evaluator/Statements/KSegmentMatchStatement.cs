using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Values;

namespace Koople.Sdk.Evaluator.Statements
{
    public class KSegmentMatchStatement : KStatement<KSegmentValue>
    {
        public KSegmentMatchStatement(IEnumerable<KSegmentValue> values) : base(null, values)
        {
        }

        public override bool Evaluate(KStore store, KUser user)
        {
            return Values
                .Select(value => store.FindSegmentByKey(value.Key()))
                .Any(segment => segment.Evaluate(store, user));
        }
    }
}