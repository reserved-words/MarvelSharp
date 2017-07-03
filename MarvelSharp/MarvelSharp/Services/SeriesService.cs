using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A service for fetching details of Marvel comic series
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
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetAllAsync(int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllSeries, limit, offset, criteria);
        }

        /// <summary>
        /// Fetches details for the specified comic series
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <returns></returns>
        public async Task<Response<Series>> GetByIdAsync(int seriesId)
        {
            return await GetSingle(string.Format(UrlSuffixSeriesById, seriesId));
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified character appears, with optional filters.
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterSeries, characterId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified creator's work appears, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorSeries, creatorId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified event takes place, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventSeries, eventId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic series in which the specified story takes place, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStorySeries, storyId), limit, offset, criteria);
        }
    }
}
