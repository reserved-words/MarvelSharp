using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A service for fetching details of Marvel comic events
    /// </summary>
    public class EventService : BaseService<Event>
    {
        /// <summary>
        /// Initializes a new instance of the EventService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public EventService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.EventParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal EventService(IHttpService httpService, IParser<Event> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of events, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetAllAsync(int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllEvents, limit, offset, criteria);
        }

        /// <summary>
        /// Fetches details for the specified event
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns></returns>
        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(UrlSuffixEventById, eventId));
        }

        /// <summary>
        /// Fetches a list of events in which the specified character appears, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterEvents, characterId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of events in which a specific comic appears, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicEvents, comicId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of events featuring the work of a specific creator, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorEvents, creatorId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of events which occur in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesEvents, seriesId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of events in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryEvents, storyId), limit, offset, criteria);
        }
    }
}
