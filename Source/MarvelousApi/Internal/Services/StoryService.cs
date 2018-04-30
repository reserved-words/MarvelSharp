using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelousApi.Criteria;
using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Services
{
   public class StoryService : BaseService<Story>
    {
        public StoryService(IHttpService httpService, IParser<Story> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Story>>> GetAllAsync(int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(MarvelApiResources.UrlSuffixAllStories, limit, offset, criteria);
        }

        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(MarvelApiResources.UrlSuffixStoryById, storyId));
        }

        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCharacterStories, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixComicStories, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCreatorStories, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixEventStories, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixSeriesStories, seriesId), limit, offset, criteria);
        }
    }
}
