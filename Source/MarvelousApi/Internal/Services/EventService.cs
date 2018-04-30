using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelousApi.Criteria;
using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Services
{
    public class EventService : BaseService<Event>
    {
        public EventService(IHttpService httpService, IParser<Event> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Event>>> GetAllAsync(int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(MarvelApiResources.UrlSuffixAllEvents, limit, offset, criteria);
        }

        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(MarvelApiResources.UrlSuffixEventById, eventId));
        }

        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCharacterEvents, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixComicEvents, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCreatorEvents, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixSeriesEvents, seriesId), limit, offset, criteria);
        }

        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, EventCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixStoryEvents, storyId), limit, offset, criteria);
        }
    }
}
