using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace StackOverflow.Common.Utils
{
    public static class EncryptionUtils
    {
        private const int SaltLength = 5;
        private const int NumBytes = 50;
        private const int Iteration = 1;
        private const string SaltDelimeter = "//";

        public static string Encrypt(this string str)
        {
            var encoding = Encoding.UTF8;
            var salt = CreateRandomString(SaltLength);
            var array = KeyDerivation.Pbkdf2(str, encoding.GetBytes(salt), KeyDerivationPrf.HMACSHA256, Iteration, NumBytes);

            return encoding.GetString(array) + SaltDelimeter + salt;
        }

        public static bool CompareWithEncrypted(this string source, string encryptedString)
        {
            var encoding = Encoding.UTF8;
            var salt = encryptedString.Substring(
                encryptedString.IndexOf(SaltDelimeter, StringComparison.Ordinal) + SaltDelimeter.Length, SaltLength);
            var encryptedBytes =
                KeyDerivation.Pbkdf2(source, encoding.GetBytes(salt), KeyDerivationPrf.HMACSHA256, Iteration, NumBytes);
            var encryptedBytesString = encoding.GetString(encryptedBytes);
            return encryptedBytesString ==
                   encryptedString[..(encryptedString.Length - SaltLength - SaltDelimeter.Length)];
        }

        public static string CreateRandomString(int length)
        {
            var rnd = new Random();
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; i++) stringBuilder.Append((char)rnd.Next(0, 255));

            return stringBuilder.ToString();
        }

        [Obsolete]
        public static string Decrypt(this string str)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
                if (i % 2 == 0)
                    stringBuilder.Append(str[i] - i);
                else
                    stringBuilder.Append(str[i] + i);

            return stringBuilder.ToString();
        }
    }
}