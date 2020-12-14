using System;
using System.Collections.Generic;
using System.Linq;
using Koople.Sdk.Evaluator.Values;
using Koople.Sdk.Values;

namespace Koople.Sdk
{
    public class KUserAttribute
    {
        public string Name;
        public object Value;

        public KUserAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    public class KUser
    {
        private readonly string _identity;
        private readonly Dictionary<string, IKValue> _attributes;

        public KUser(string identity, Dictionary<string, IKValue> attributes)
        {
            _identity = identity;
            _attributes = attributes;
        }

        public string GetIdentity() => _identity;

        public IKValue GetValue(string attr) => _attributes.GetValueOrDefault(attr);

        public KStringValue GetStringValue(string attr) => GetValue(attr)?.AsString();

        public KBooleanValue GetBooleanValue(string attr) => GetValue(attr)?.AsBoolean();

        public KNumberValue GetNumberValue(string attr) => GetValue(attr)?.AsNumber();

        public static KUser Create(string identity)
        {
            return new KUser(identity, new Dictionary<string, IKValue>());
        }

        public static KUser Create(string identity, IEnumerable<KUserAttribute> attributes)
        {
            var kValues = attributes.ToDictionary(x => x.Name, value => IKValue.Create(value.Value));
            return new KUser(identity, kValues);
        }

        public KUser With(string key, object value)
        {
            _attributes.Add(key, IKValue.Create(value));
            return this;
        }
        
        public static KUser Anonymous() => Create($"anonymous-{Guid.NewGuid().ToString()}");
    }
}