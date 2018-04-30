using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarvelousApi.Internal.Interfaces;

namespace MarvelousApi.Internal.Utilities
{
    public class UrlBuilder : IUrlBuilder
    {
        private readonly IHasher _hasher;
        private readonly IDateProvider _dateProvider;

        public UrlBuilder(IHasher hasher, IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _hasher = hasher;
        }

        public string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, int? limit = null, int? offset = null, ICriteria criteria = null)
        {
            var url = $"{MarvelApiResources.UrlBase}{urlSuffix}";

            var dictionary = criteria?.ToDictionary() ?? new Dictionary<string, string>();

            var timestamp = _dateProvider.GetCurrentTime().ToString(MarvelApiResources.ParameterTimeStampFormat);

            dictionary.Add(MarvelApiResources.ParameterApiKey, apiPublicKey);
            dictionary.Add(MarvelApiResources.ParameterTimeStamp, timestamp);
            dictionary.Add(MarvelApiResources.ParameterHash, _hasher.Hash(timestamp + apiPrivateKey + apiPublicKey));

            if (limit.HasValue)
            {
                dictionary.Add(MarvelApiResources.ParameterLimit, limit.Value.ToString());
            }

            if (offset.HasValue)
            {
                dictionary.Add(MarvelApiResources.ParameterOffset, offset.Value.ToString());
            }

            return url + "?" + string.Join("&", dictionary.Select(p => $"{p.Key}={HttpUtility.UrlPathEncode(p.Value)}"));
        }
    }
}
