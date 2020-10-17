using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace fflags_sdk_cs
{
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

        private int HashValue(string identifier)
        {
            var sha1 = new SHA1Managed();
            var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(identifier));

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("x2"));
            }

            var str = sb.ToString().Substring(0, 7);

            return int.Parse(str, NumberStyles.HexNumber) % 100;
        }
    }
}