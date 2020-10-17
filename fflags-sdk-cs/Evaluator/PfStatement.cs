using System.Collections.Generic;
using fflags_sdk_cs.Evaluator.Values;

namespace fflags_sdk_cs.Evaluator
{
    public abstract class PfStatement<T> : IPfEvaluable
        where T : IPfValue
    {
        protected readonly string Attribute;
        protected readonly IEnumerable<T> Values;

        protected PfStatement(string attribute, IEnumerable<T> values)
        {
            Attribute = attribute;
            Values = values;
        }

        public abstract bool Evaluate(PfStore store, PfUser user);
    }
}