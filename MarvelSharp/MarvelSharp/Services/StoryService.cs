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
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetAllAsync(StoryParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllStories, parameters);
        }

        /// <summary>
        /// Fetches details for the specified story
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(MarvelApi.GetStory, storyId), null);
        }

        /// <summary>
        /// Fetches a list of comic stories featuring the specified character, with optional filters
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterStories, characterId), parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories in a specific comic issue, with optional filters
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicStories, comicId), parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories by the specified creator, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorStories, creatorId), parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified event, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetByEventAsync(int eventId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventStories, eventId), parameters);
        }

        /// <summary>
        /// Fetches a list of comic stories from the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesStories, seriesId), parameters);
        }
    }
}
