using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
   public class CreatorService : BaseService<Creator>
    {
        public CreatorService(IHttpService httpService, IParser<Creator> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Creator>>> GetAllAsync(int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllCreators, limit, offset, criteria);
        }

        public async Task<Response<Creator>> GetByIdAsync(int creatorId)
        {
            return await GetSingle(string.Format(UrlSuffixCreatorById, creatorId));
        }

        public async Task<Response<List<Creator>>> GetByComicAsync(int comicId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixComicCreators, comicId), limit, offset, criteria);
        }

        public async Task<Response<List<Creator>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventCreators, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Creator>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesCreators, seriesId), limit, offset, criteria);
        }

        public async Task<Response<List<Creator>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, CreatorCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryCreators, storyId), limit, offset, criteria);
        }
    }
}
