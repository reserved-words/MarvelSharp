using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelousApi.Criteria;
using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Services
{
	public class ComicService : BaseService<Comic>
    {
	    public ComicService(IHttpService httpService, IParser<Comic> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

	    public async Task<Response<List<Comic>>> GetAllAsync(int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(MarvelApiResources.UrlSuffixAllComics, limit, offset, criteria);
        }

	    public async Task<Response<Comic>> GetByIdAsync(int comicId)
        {
            return await GetSingle(string.Format(MarvelApiResources.UrlSuffixComicById, comicId));
        }

        public async Task<Response<List<Comic>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCharacterComics, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Comic>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCreatorComics, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Comic>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixEventComics, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Comic>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixSeriesComics, seriesId), limit, offset, criteria);
        }

        public async Task<Response<List<Comic>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixStoryComics, storyId), limit, offset, criteria);
        }
    }
}
