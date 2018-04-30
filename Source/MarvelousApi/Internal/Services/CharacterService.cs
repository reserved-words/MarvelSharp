using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelousApi.Criteria;
using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Services
{
	public class CharacterService : BaseService<Character>
    {
        public CharacterService(IHttpService httpService, IParser<Character> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comic characters, with optional filters
        /// </summary>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetAllAsync(int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(MarvelApiResources.UrlSuffixAllCharacters, limit, offset, criteria);
        }

        public async Task<Response<Character>> GetByIdAsync(int characterId)
        {
            return await GetSingle(string.Format(MarvelApiResources.UrlSuffixCharacterById, characterId));
        }

        public async Task<Response<List<Character>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixComicCharacters, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Character>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixEventCharacters, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Character>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixSeriesCharacters, seriesId), limit, offset, criteria);
        }

        public async Task<Response<List<Character>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixStoryCharacters, storyId), limit, offset, criteria);
        }
    }
}
