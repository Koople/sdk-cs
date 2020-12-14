namespace Koople.Sdk.Values
{
    public class KSegmentValue : KStringValue
    {
        public KSegmentValue(string value) : base(value)
        {
        }

        public string Key() => Value;
    }
}