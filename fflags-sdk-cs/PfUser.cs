using System.Collections.Generic;
using fflags_sdk_cs.Values;

namespace fflags_sdk_cs
{
    public class PfUserAttribute
    {
        public readonly string Name;
        public readonly object Value;

        public PfUserAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    public class PfUser
    {
        public readonly string Identity;
        public readonly Dictionary<string, PfValue<object>> Attributes;

        public PfValue<object> GetValue(string attr)
        {
            return Attributes[attr];
        }
    }
}