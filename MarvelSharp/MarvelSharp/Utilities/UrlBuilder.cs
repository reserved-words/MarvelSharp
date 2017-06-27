using MarvelSharp.Interfaces;
using MarvelSharp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelSharp.Utilities
{
    internal class UrlBuilder : IUrlBuilder
    {
        private readonly IHasher _hasher;

        public UrlBuilder(IHasher hasher)
        {
            _hasher = hasher;
        }

        public string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, ParametersBase parameters = null)
        {
            var url = $"{MarvelApi.Base}{urlSuffix}";

            var dictionary = parameters?.ToDictionary() ?? new Dictionary<string, string>();

            var timestamp = DateTime.Now.ToString("HHMMddmmss");

            dictionary.Add("apikey", apiPublicKey);
            dictionary.Add("ts", timestamp);
            dictionary.Add("hash", _hasher.Hash(timestamp + apiPrivateKey + apiPublicKey));

            return url + "?" + string.Join("&", dictionary.Select(p => string.Format("{0}={1}", p.Key, HttpUtility.UrlPathEncode(p.Value))));
        }
    }
}
