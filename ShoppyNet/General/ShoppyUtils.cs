using System.Security.Cryptography;
using System.Text;

namespace Shoppy
{
    public static class ShoppyUtils
    {
        public static string ComputeHash(byte[] key, string body)
        {
            using (HMACSHA512 hmacSha256 = new HMACSHA512(key))
            {
                var computed = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(body));

                string computedStr = "";
                for (int i = 0; i < computed.Length; i++)
                    computedStr += computed[i].ToString("x2");

                return computedStr;
            }
        }
    }
}
