using System;

namespace MyFinance.Tools
{
    public class StringHandler
    {
        public static string RemoverFormatacaoCPFCNPJ(string c)
        {
            if (!string.IsNullOrEmpty(c))
                return c.Replace(".", "").Replace("-", "").Replace("/", "");
            else
                c = "00000000000";

            return c;
        }

        public static string GetRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
