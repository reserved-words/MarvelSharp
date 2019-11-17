using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.Core.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
   internal class StoryService : BaseService<Story>
    {
        internal StoryService(IHttpService httpService, IParser<Story> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal async Task<Response<List<Story>>> GetAllAsync(int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllStories, limit, offset, criteria);
        }

        internal async Task<Response<Story>> GetByIdAsync(int storyId)
        {
            return await GetSingle(string.Format(UrlSuffixStoryById, storyId));
        }

        internal async Task<Response<List<Story>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterStories, characterId), limit, offset, criteria);
        }

        internal async Task<Response<List<Story>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicStories, comicId), limit, offset, criteria);
        }

        internal async Task<Response<List<Story>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorStories, creatorId), limit, offset, criteria);
        }

        internal async Task<Response<List<Story>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventStories, eventId), limit, offset, criteria);
        }

        internal async Task<Response<List<Story>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, StoryCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesStories, seriesId), limit, offset, criteria);
        }
    }
}
