using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
    internal class ComicService : BaseService<Comic>
    {
        internal ComicService(IHttpService httpService, IParser<Comic> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal async Task<Response<List<Comic>>> GetAllAsync(int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllComics, limit, offset, criteria);
        }

        internal async Task<Response<Comic>> GetByIdAsync(int comicId)
        {
            return await GetSingle(string.Format(UrlSuffixComicById, comicId));
        }

        internal async Task<Response<List<Comic>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterComics, characterId), limit, offset, criteria);
        }

        internal async Task<Response<List<Comic>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorComics, creatorId), limit, offset, criteria);
        }

        internal async Task<Response<List<Comic>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventComics, eventId), limit, offset, criteria);
        }

        internal async Task<Response<List<Comic>>> GetBySeriesAsync(int seriesId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixSeriesComics, seriesId), limit, offset, criteria);
        }

        internal async Task<Response<List<Comic>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, ComicCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStoryComics, storyId), limit, offset, criteria);
        }
    }
}
