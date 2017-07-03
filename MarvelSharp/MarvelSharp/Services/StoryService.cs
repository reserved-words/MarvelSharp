using MarvelSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A service for fetching details of Marvel comic stories
    /// </summary>
    public class StoryService : BaseService<Story>
    {
        /// <summary>
        /// Initializes a new instance of the StoryService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public StoryService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.StoryParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal StoryService(IHttpService httpService, IParser<Story> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of stories, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetAllAsync(int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllStories, limit, offset, criteria);
        }

        /// <summary>
        /// Fetches details for the specified story
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(UrlSuffixStoryById, storyId));
        }

        /// <summary>
        /// Fetches a list of comic stories featuring the specified character, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterStories, characterId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic stories in a specific comic issue, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicStories, comicId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic stories by the specified creator, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorStories, creatorId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventStories, eventId), limit, offset, criteria);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesStories, seriesId), limit, offset, criteria);
        }
    }
}
