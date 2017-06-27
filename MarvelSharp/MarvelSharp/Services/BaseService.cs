using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    public class BaseService<T>
    {
        private readonly string _apiPublicKey;
        private readonly string _apiPrivateKey;
        private readonly IHttpService _httpService;
        private readonly IUrlBuilder _urlBuilder;
        private readonly IParser<T> _parser;

        internal BaseService(IHttpService apiService, IParser<T> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
        {
            _apiPublicKey = apiPublicKey;
            _apiPrivateKey = apiPrivateKey;
            _httpService = apiService;
            _parser = parser;
            _urlBuilder = urlBuilder;
        }

        protected async Task<Response<List<T>>> GetList(string urlSuffix, ParametersBase parameters)
        {
            return await GetResponse<List<T>>(urlSuffix, parameters);
        }

        protected async Task<Response<T>> GetSingle(string urlSuffix, ParametersBase parameters)
        {
            return await GetResponse<T>(urlSuffix, parameters);
        }

        private async Task<Response<T1>> GetResponse<T1>(string urlSuffix, ParametersBase parameters)
        {
            var url = _urlBuilder.BuildUrl(_apiPublicKey, _apiPrivateKey, urlSuffix, parameters);

            var httpResponse = await _httpService.GetAsync(url);

            dynamic parsed = JObject.Parse(httpResponse);

            return _parser.GetResponse<T1>(parsed);
        }
    }
}
