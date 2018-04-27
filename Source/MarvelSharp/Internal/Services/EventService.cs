using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
    public class EventService : BaseService<Event>
    {
        public EventService(IHttpService httpService, IParser<Event> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Event>>> GetAllAsync(int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllEvents, limit, offset, criteria);
        }

        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(UrlSuffixEventById, eventId));
        }

        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterEvents, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicEvents, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorEvents, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesEvents, seriesId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryEvents, storyId), limit, offset, criteria);
        }
    }
}
