﻿using System.Security.Cryptography;
using System.Text;
using MarvelSharp.Internal.Interfaces;

namespace MarvelSharp.Internal.Utilities
{
    internal class MD5Hasher : IHasher
    {
        public string Hash(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                foreach (var item in data)
                {
                    sBuilder.Append(item.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
