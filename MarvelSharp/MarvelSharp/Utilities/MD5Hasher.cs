using MarvelSharp.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MarvelSharp.Utilities
{
    public class MD5Hasher : IHasher
    {
        public string Hash(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
