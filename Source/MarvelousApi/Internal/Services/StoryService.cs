using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
   public class StoryService : BaseService<Story>
    {
        public StoryService(IHttpService httpService, IParser<Story> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Story>>> GetAllAsync(int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllStories, limit, offset, criteria);
        }

        public async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(UrlSuffixStoryById, storyId));
        }

        public async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterStories, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicStories, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorStories, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventStories, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesStories, seriesId), limit, offset, criteria);
        }
    }
}
