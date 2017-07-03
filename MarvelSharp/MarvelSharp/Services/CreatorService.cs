using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A service for fetching details of Marvel comic creators
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
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetAllAsync(int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllCreators, limit, offset, criteria);
        }

        /// <summary>
        /// Fetches details for the specified comic creator
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <returns></returns>
        public async Task<Response<Creator>> GetByIdAsync(int creatorId)
        {
            return await GetSingle(string.Format(UrlSuffixCreatorById, creatorId));
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified comic, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicCreators, comicId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventCreators, eventId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesCreators, seriesId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic creators whose work appears in the specified story, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryCreators, storyId), limit, offset, criteria);
        }
    }
}
