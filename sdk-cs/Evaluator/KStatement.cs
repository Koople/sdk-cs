using System.Collections.Generic;
using Koople.Sdk.Evaluator.Values;

namespace Koople.Sdk.Evaluator
{
    public abstract class KStatement<T> : IKEvaluable
        where T : IKValue
    {
        protected readonly string Attribute;
        protected readonly IEnumerable<T> Values;

        protected KStatement(string attribute, IEnumerable<T> values)
        {
            Attribute = attribute;
            Values = values;
        }

        public abstract bool Evaluate(KStore store, KUser user);
    }
}