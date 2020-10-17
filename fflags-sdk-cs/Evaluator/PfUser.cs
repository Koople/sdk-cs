using System.Collections.Generic;
using System.Linq;
using fflags_sdk_cs.Evaluator.Values;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs
{
    public class PfUserAttribute
    {
        public string Name;
        public object Value;

        public PfUserAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    public class PfUser
    {
        private readonly string _identity;
        private readonly Dictionary<string, IPfValue> _attributes;

        public PfUser(string identity, Dictionary<string, IPfValue> attributes)
        {
            _identity = identity;
            _attributes = attributes;
        }

        public string GetIdentity() => _identity;

        public IPfValue GetValue(string attr) => _attributes.GetValueOrDefault(attr);

        public PfStringValue GetStringValue(string attr) => GetValue(attr)?.AsString();

        public PfBooleanValue GetBooleanValue(string attr) => GetValue(attr)?.AsBoolean();

        public PfNumberValue GetNumberValue(string attr) => GetValue(attr)?.AsNumber();

        public static PfUser Create(string identity)
        {
            return new PfUser(identity, new Dictionary<string, IPfValue>());
        }

        public static PfUser Create(string identity, IEnumerable<PfUserAttribute> attributes)
        {
            var pfValues = attributes.ToDictionary(x => x.Name, value => IPfValue.Create(value.Value));
            return new PfUser(identity, pfValues);
        }
    }
}