using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelousApi.Criteria;
using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Services
{
    public class SeriesService : BaseService<Series>
    {
        public SeriesService(IHttpService httpService, IParser<Series> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Series>>> GetAllAsync(int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(MarvelApiResources.UrlSuffixAllSeries, limit, offset, criteria);
        }

        public async Task<Response<Series>> GetByIdAsync(int seriesId)
        {
            return await GetSingle(string.Format(MarvelApiResources.UrlSuffixSeriesById, seriesId));
        }

        public async Task<Response<List<Series>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCharacterSeries, characterId), limit, offset, criteria);
        }

        public async Task<Response<List<Series>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixCreatorSeries, creatorId), limit, offset, criteria);
        }

        public async Task<Response<List<Series>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixEventSeries, eventId), limit, offset, criteria);
        }

        public async Task<Response<List<Series>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(MarvelApiResources.UrlSuffixStorySeries, storyId), limit, offset, criteria);
        }
    }
}
