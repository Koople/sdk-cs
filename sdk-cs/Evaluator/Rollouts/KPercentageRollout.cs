using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Koople.Sdk.Evaluator.Rollouts;

public class KPercentageRollout
{
    protected int Percentage { get; }

    public KPercentageRollout()
    {
    }

    private KPercentageRollout(int percentage)
    {
        Percentage = percentage;
    }

    public bool Evaluate(string identifier)
    {
        var value = HashValue(identifier);
        return Percentage >= value;
    }

    public static KPercentageRollout Create(int percentage)
    {
        return new KPercentageRollout(percentage);
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