using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Internal.Services
{
    internal class SeriesService : BaseService<Series>
    {
        internal SeriesService(IHttpService httpService, IParser<Series> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal async Task<Response<List<Series>>> GetAllAsync(int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(UrlSuffixAllSeries, limit, offset, criteria);
        }

        internal async Task<Response<Series>> GetByIdAsync(int seriesId)
        {
            return await GetSingle(string.Format(UrlSuffixSeriesById, seriesId));
        }

        internal async Task<Response<List<Series>>> GetByCharacterAsync(int characterId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCharacterSeries, characterId), limit, offset, criteria);
        }

        internal async Task<Response<List<Series>>> GetByCreatorAsync(int creatorId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixCreatorSeries, creatorId), limit, offset, criteria);
        }

        internal async Task<Response<List<Series>>> GetByEventAsync(int eventId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixEventSeries, eventId), limit, offset, criteria);
        }

        internal async Task<Response<List<Series>>> GetByStoryAsync(int storyId, int? limit = null, int? offset = null, SeriesCriteria criteria = null)
        {
            return await GetList(string.Format(UrlSuffixStorySeries, storyId), limit, offset, criteria);
        }
    }
}
