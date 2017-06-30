using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comic stories
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
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetAllAsync(int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllStories, limit, offset, parameters);
        }

        /// <summary>
        /// Fetches details for the specified story
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(MarvelApi.GetStory, storyId));
        }

        /// <summary>
        /// Fetches a list of comic stories featuring the specified character, with optional filters
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterStories, characterId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories in a specific comic issue, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicStories, comicId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories by the specified creator, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorStories, creatorId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified event, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventStories, eventId), limit, offset, parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesStories, seriesId), limit, offset, parameters);
        }
    }
}
