using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MarvelSharp.MarvelApiResources;

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
            var url = $"{UrlBase}{urlSuffix}";

            var dictionary = parameters?.ToDictionary() ?? new Dictionary<string, string>();

            var timestamp = _dateProvider.GetCurrentTime().ToString(ParameterTimeStampFormat);

            dictionary.Add(ParameterApiKey, apiPublicKey);
            dictionary.Add(ParameterTimeStamp, timestamp);
            dictionary.Add(ParameterHash, _hasher.Hash(timestamp + apiPrivateKey + apiPublicKey));

            if (limit.HasValue)
            {
                dictionary.Add(ParameterLimit, limit.Value.ToString());
            }

            if (offset.HasValue)
            {
                dictionary.Add(ParameterOffset, offset.Value.ToString());
            }

            return url + "?" + string.Join("&", dictionary.Select(p => $"{p.Key}={HttpUtility.UrlPathEncode(p.Value)}"));
        }
    }
}
