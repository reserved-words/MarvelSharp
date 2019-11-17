using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
    internal class CharacterService : BaseService<Character>
    {
        internal CharacterService(IHttpService httpService, IParser<Character> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
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
        internal async Task<Response<List<Character>>> GetAllAsync(int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllCharacters, limit, offset, criteria);
        }

        internal async Task<Response<Character>> GetByIdAsync(int characterId)
        {
            return await GetSingle(string.Format(UrlSuffixCharacterById, characterId));
        }

        internal async Task<Response<List<Character>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicCharacters, comicId), limit, offset, criteria);
        }

        internal async Task<Response<List<Character>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventCharacters, eventId), limit, offset, criteria);
        }

        internal async Task<Response<List<Character>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesCharacters, seriesId), limit, offset, criteria);
        }

        internal async Task<Response<List<Character>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CharacterCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryCharacters, storyId), limit, offset, criteria);
        }
    }
}
