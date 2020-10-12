using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace fflags_sdk_cs
{
    public enum PfTargeting
    {
        DisabledForAll,
        EnabledForSomeUsers,
        EnabledForAll
    }

    public class PfPercentageRollout
    {
        private readonly int _percentage;

        private PfPercentageRollout(int percentage)
        {
            _percentage = percentage;
        }

        public bool Evaluate(string identifier)
        {
            var value = HashValue(identifier);
            return _percentage >= value;
        }

        public static PfPercentageRollout Create(int percentage)
        {
            return new PfPercentageRollout(percentage);
        }

        private uint HashValue(string identifier)
        {
            var sha1 = new SHA1Managed();
            var plaintextBytes = Encoding.UTF8.GetBytes(identifier);
            var hashBytes = sha1.ComputeHash(plaintextBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.AppendFormat("{0:x2}", hashByte);
            }

            var str = sb.ToString();

            return uint.Parse(str, NumberStyles.HexNumber) % 100;
        }
    }

    public class PfFeatureFlag
    {
        public readonly string key;
        public readonly PfTargeting targeting;
        public readonly IEnumerable<string> identities;
        public readonly List<PFInlineRule> rules;
        public readonly bool enableRollout;
        public readonly PfPercentageRollout rollout;
    }
}