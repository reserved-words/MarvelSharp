using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelSharp.Utilities
{
    internal class UrlBuilder : IUrlBuilder
    {
        private readonly IHasher _hasher;
        private readonly IDateProvider _dateProvider;

        public UrlBuilder(IHasher hasher, IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _hasher = hasher;
        }

        public string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, int? limit = null, int? offset = null, IParameters parameters = null)
        {
            var url = $"{MarvelApi.Base}{urlSuffix}";

            var dictionary = parameters?.ToDictionary() ?? new Dictionary<string, string>();

            var timestamp = _dateProvider.GetCurrentTime().ToString(MarvelApi.ParameterTimeStampFormat);

            dictionary.Add(MarvelApi.ParameterApiKey, apiPublicKey);
            dictionary.Add(MarvelApi.ParameterTimeStamp, timestamp);
            dictionary.Add(MarvelApi.ParameterHash, _hasher.Hash(timestamp + apiPrivateKey + apiPublicKey));

            if (limit.HasValue)
            {
                dictionary.Add(MarvelApi.ParameterLimit, limit.Value.ToString());
            }

            if (offset.HasValue)
            {
                dictionary.Add(MarvelApi.ParameterOffset, offset.Value.ToString());
            }

            return url + "?" + string.Join("&", dictionary.Select(p => $"{p.Key}={HttpUtility.UrlPathEncode(p.Value)}"));
        }
    }
}
