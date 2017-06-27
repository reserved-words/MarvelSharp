using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Model;
using MarvelSharp.Parameters;

namespace MarvelSharp.Services
{
    public class CharacterService : BaseService<Character>
    {
        public CharacterService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.CharacterParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal CharacterService(IHttpService httpService, IParser<Character> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Character>>> GetAllAsync(CharacterParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllCharacters, parameters);
        }

        public async Task<Response<Character>> GetByIdAsync(int characterId)
        {
            return await GetSingle(string.Format(MarvelApi.GetCharacter, characterId), null);
        }

        public async Task<Response<List<Character>>> GetByComicAsync(int comicId, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicCharacters, comicId), parameters);
        }

        public async Task<Response<List<Character>>> GetByEventAsync(int eventId, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventCharacters, eventId), parameters);
        }

        public async Task<Response<List<Character>>> GetBySeriesAsync(int seriesId, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesCharacters, seriesId), parameters);
        }

        public async Task<Response<List<Character>>> GetByStoryAsync(int storyId, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryCharacters, storyId), parameters);
        }
    }
}
