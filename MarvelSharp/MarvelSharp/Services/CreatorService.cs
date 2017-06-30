using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comic creators
    /// </summary>
    public class CreatorService : BaseService<Creator>
    {
        /// <summary>
        /// Initializes a new instance of the CreatorService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public CreatorService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.CreatorParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal CreatorService(IHttpService httpService, IParser<Creator> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comic creators, with optional filters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetAllAsync(int? limit = null, int? offset = null, CreatorParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllCreators, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified comic creator
        /// </summary>
        /// <param name="creatorId"></param>
        /// <returns></returns>
        public async Task<Response<Creator>> GetByIdAsync(int creatorId)
        {
            return await GetSingle(string.Format(MarvelApi.GetCreator, creatorId));
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified comic, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicCreators, comicId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified event, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventCreators, eventId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesCreators, seriesId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified story, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryCreators, storyId), limit, offset, parameters);
        }
    }
}
