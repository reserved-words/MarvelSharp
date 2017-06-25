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
    public class EventService : BaseService<Event>
    {
        public EventService(IHttpService httpService, IParser<Event> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Event>>> GetAllAsync(EventParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllEvents, parameters);
        }

        public async Task<Response<Event>> GetByIdAsync(int eventId)
        {
            return await GetSingle(string.Format(MarvelApi.GetEvent, eventId), null);
        }

        public async Task<Response<List<Event>>> GetByCharacterAsync(int characterId, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterEvents, characterId), parameters);
        }

        public async Task<Response<List<Event>>> GetByComicAsync(int comicId, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicEvents, comicId), parameters);
        }

        public async Task<Response<List<Event>>> GetByCreatorAsync(int creatorId, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorEvents, creatorId), parameters);
        }

        public async Task<Response<List<Event>>> GetBySeriesAsync(int seriesId, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesEvents, seriesId), parameters);
        }

        public async Task<Response<List<Event>>> GetByStoryAsync(int storyId, EventParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryEvents, storyId), parameters);
        }
    }
}
