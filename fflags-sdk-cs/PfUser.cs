using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs
{
    public class PfUser
    {
        private readonly string _identity;
        private readonly Dictionary<string, PfValue<object>> _attributes;

        public PfUser(string identity, Dictionary<string, PfValue<object>> attributes)
        {
            _identity = identity;
            _attributes = attributes;
        }

        public string GetIdentity() => _identity;

        public IPfValue GetValue(string attr) => _attributes[attr];

        public PfStringValue GetStringValue(string attr) => _attributes[attr]?.AsString();
        
        public PfBooleanValue GetBooleanValue(string attr) => _attributes[attr]?.AsBoolean();
        
        public PfNumberValue GetNumberValue(string attr) => _attributes[attr]?.AsNumber();
    }
}