using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    public class SeriesService : BaseService<Series>
    {
        public SeriesService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.SeriesParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal SeriesService(IHttpService httpService, IParser<Series> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Series>>> GetAllAsync(SeriesParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllSeries, parameters);
        }

        public async Task<Response<Series>> GetByIdAsync(int seriesId)
        {
            return await GetSingle(string.Format(MarvelApi.GetSeries, seriesId), null);
        }

        public async Task<Response<List<Series>>> GetByCharacterAsync(int characterId, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterSeries, characterId), parameters);
        }

        public async Task<Response<List<Series>>> GetByCreatorAsync(int creatorId, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorSeries, creatorId), parameters);
        }

        public async Task<Response<List<Series>>> GetByEventAsync(int eventId, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventSeries, eventId), parameters);
        }

        public async Task<Response<List<Series>>> GetByStoryAsync(int storyId, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStorySeries, storyId), parameters);
        }
    }
}
