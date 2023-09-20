using System;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Koople.Sdk.Evaluator.Values;

[JsonConverter(typeof(JsonSubtypes), "type")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KStringValue), "string")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KNumberValue), "number")]
[JsonSubtypes.KnownSubTypeAttribute(typeof(KSegmentValue), "segment")]
public abstract class IKValue
{
    public abstract bool IsEquals(IKValue other);
    public abstract bool NotEquals(IKValue other);

    public abstract object GetValue();

    public abstract KStringValue AsString();
    public abstract KNumberValue AsNumber();
    public abstract KBooleanValue AsBoolean();

    public static IKValue Create(object value)
    {
        switch (value)
        {
            case bool boolValue:
                return new KBooleanValue(boolValue);
            case string stringValue:
                return new KStringValue(stringValue);
            case int intValue:
                return new KNumberValue(intValue);
            default:
                throw new UserAttributeTypeNotSupportedException();
        }
    }
}

public class UserAttributeTypeNotSupportedException : Exception
{
}

public abstract class KValue<T> : IKValue
{
    public readonly T Value;

    protected KValue(T value)
    {
        Value = value;
    }

    public override object GetValue() => Value;

    public override KStringValue AsString()
    {
        if (GetType() == typeof(KStringValue))
            return this as KStringValue;

        return null;
    }

    public override KNumberValue AsNumber()
    {
        if (GetType() == typeof(KNumberValue))
            return this as KNumberValue;

        return null;
    }

    public override KBooleanValue AsBoolean()
    {
        if (GetType() == typeof(KBooleanValue))
            return this as KBooleanValue;

        return null;
    }

    public override bool IsEquals(IKValue other) => GetType() == other.GetType() && Value.Equals(other.GetValue());

    public override bool NotEquals(IKValue other) => !Equals(other);
}