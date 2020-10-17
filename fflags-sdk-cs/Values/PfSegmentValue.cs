namespace fflags_sdk_cs.Values
{
    public class PfSegmentValue : PfStringValue
    {
        public PfSegmentValue(string value) : base(value)
        {
        }

        public string Key() => Value;
    }
}