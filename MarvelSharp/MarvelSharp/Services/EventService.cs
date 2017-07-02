using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comic events
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
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetAllAsync(int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(UrlSuffixAllEvents, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(UrlSuffixEventById, eventId));
        }

        /// <summary>
        /// Fetches a list of events in which the specified character appears, with optional filters
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterEvents, characterId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events in which a specific comic appears, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixComicEvents, comicId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events featuring the work of a specific creator, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorEvents, creatorId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events which occur in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesEvents, seriesId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixStoryEvents, storyId), limit, offset, parameters);
        }
    }
}
