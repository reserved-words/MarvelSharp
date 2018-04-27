using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Services
{
	public class BaseService<T>
    {
        private readonly string _apiPublicKey;
        private readonly string _apiPrivateKey;
        private readonly IHttpService _httpService;
        private readonly IUrlBuilder _urlBuilder;
        private readonly IParser<T> _parser;

        public BaseService(IHttpService apiService, IParser<T> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
        {
            _apiPublicKey = apiPublicKey;
            _apiPrivateKey = apiPrivateKey;
            _httpService = apiService;
            _parser = parser;
            _urlBuilder = urlBuilder;
        }

        protected async Task<Response<List<T>>> GetList(string urlSuffix, int? limit, int? offset, BaseCriteria criteria)
        {
            return await GetResponse<List<T>>(urlSuffix, limit, offset, criteria);
        }

        protected async Task<Response<T>> GetSingle(string urlSuffix)
        {
            return await GetResponse<T>(urlSuffix, 1, 0, null);
        }

        private async Task<Response<T1>> GetResponse<T1>(string urlSuffix, int? limit, int? offset, BaseCriteria criteria)
        {
            var url = _urlBuilder.BuildUrl(_apiPublicKey, _apiPrivateKey, urlSuffix, limit, offset, criteria);

            var httpResponse = await _httpService.GetAsync(url);

            dynamic parsed = JObject.Parse(httpResponse);

            return _parser.GetResponse<T1>(parsed);
        }
    }
}
