using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comic characters
    /// </summary>
    public class CharacterService : BaseService<Character>
    {
        /// <summary>
        /// Initializes a new instance of the CharacterService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public CharacterService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.CharacterParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal CharacterService(IHttpService httpService, IParser<Character> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comic characters, with optional filters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetAllAsync(int? limit = null, int? offset = null, CharacterParameters parameters = null)
        {
            return await GetList(UrlSuffixAllCharacters, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified character
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public async Task<Response<Character>> GetByIdAsync(int characterId)
        {
            return await GetSingle(string.Format(UrlSuffixCharacterById, characterId));
        }

        /// <summary>
        /// Fetches a list of characters that appear in a specific comic, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixComicCharacters, comicId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of characters that appear in a specific event, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixEventCharacters, eventId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of characters that appear in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesCharacters, seriesId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic characters appearing in the specified story, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CharacterParameters parameters = null)
        {
            return await GetList(string.Format(UrlSuffixStoryCharacters, storyId), limit, offset, parameters);
        }
    }
}
