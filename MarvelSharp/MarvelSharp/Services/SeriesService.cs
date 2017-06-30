using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comic series
    /// </summary>
    public class SeriesService : BaseService<Series>
    {
        /// <summary>
        /// Initializes a new instance of the SeriesService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public SeriesService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.SeriesParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal SeriesService(IHttpService httpService, IParser<Series> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comic series, with optional filters
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetAllAsync(int? limit = null, int? offset = null, SeriesParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllSeries, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified comic series
        /// </summary>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        public async Task<Response<Series>> GetByIdAsync(int seriesId)
        {
            return await GetSingle(string.Format(MarvelApi.GetSeries, seriesId));
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified character appears, with optional filters.
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterSeries, characterId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified creator's work appears, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorSeries, creatorId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified event takes place, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventSeries, eventId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified story takes place, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, SeriesParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStorySeries, storyId), limit, offset, parameters);
        }
    }
}
