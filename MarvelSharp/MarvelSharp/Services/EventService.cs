using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using MarvelSharp.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await GetList(MarvelApi.GetAllEvents, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(MarvelApi.GetEvent, eventId));
        }

        /// <summary>
        /// Fetches a list of events in which the specified character appears, with optional filters
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterEvents, characterId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events in which a specific comic appears, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicEvents, comicId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events featuring the work of a specific creator, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorEvents, creatorId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events which occur in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesEvents, seriesId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of events in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryEvents, storyId), limit, offset, parameters);
        }
    }
}
