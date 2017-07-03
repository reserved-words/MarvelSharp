using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A service for fetching details of Marvel comics
    /// </summary>
    public class ComicService : BaseService<Comic>
    {
        /// <summary>
        /// Initializes a new instance of the ComicService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public ComicService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.ComicParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal ComicService(IHttpService httpService, IParser<Comic> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comics, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetAllAsync(int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllComics, limit, offset, criteria);
        }

        /// <summary>
        /// Fetches details for the specified comic
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <returns></returns>
        public async Task<Response<Comic>> GetByIdAsync(int comicId)
        {
            return await GetSingle(string.Format(UrlSuffixComicById, comicId));
        }

        /// <summary>
        /// Fetches a list of comics containing the specified character, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterComics, characterId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comics in which the work of the specified creator appears, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorComics, creatorId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comics that take place during the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventComics, eventId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comics that are published as part of the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesComics, seriesId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comics in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryComics, storyId), limit, offset, criteria);
        }
    }
}
