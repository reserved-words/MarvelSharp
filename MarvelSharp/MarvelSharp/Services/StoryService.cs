using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    public class StoryService : BaseService<Story>
    {
        public StoryService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.StoryParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal StoryService(IHttpService httpService, IParser<Story> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Story>>> GetAllAsync(StoryParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllStories, parameters);
        }

        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(MarvelApi.GetStory, storyId), null);
        }

        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterStories, characterId), parameters);
        }

        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicStories, comicId), parameters);
        }

        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, StoryParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesStories, seriesId), parameters);
        }
    }
}
