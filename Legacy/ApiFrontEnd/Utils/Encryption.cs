using System.Text;

namespace ApiFrontEnd.Utils;

public static class Encryption
{
    private static readonly int _key = 5;

    public static string Encrypt(this string incode)
    {
        var sb = new StringBuilder();

        foreach (var ch in incode) sb.Append((char)(ch + _key));

        return sb.ToString();
    }

    public static string Decrypt(this string incode)
    {
        var sb = new StringBuilder();

        foreach (var ch in incode) sb.Append((char)(ch - _key));

        return sb.ToString();
    }
}