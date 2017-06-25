using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using MarvelSharp.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    public class CreatorService : BaseService<Creator>
    {
        public CreatorService(IHttpService httpService, IParser<Creator> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Creator>>> GetAllAsync(CreatorParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllCreators, parameters);
        }

        public async Task<Response<Creator>> GetByIdAsync(int creatorId)
        {
            return await GetSingle(string.Format(MarvelApi.GetCreator, creatorId), null);
        }

        public async Task<Response<List<Creator>>> GetByComicAsync(int comicId, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetComicCreators, comicId), parameters);
        }

        public async Task<Response<List<Creator>>> GetByEventAsync(int eventId, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventCreators, eventId), parameters);
        }

        public async Task<Response<List<Creator>>> GetBySeriesAsync(int seriesId, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesCreators, seriesId), parameters);
        }

        public async Task<Response<List<Creator>>> GetByStoryAsync(int storyId, CreatorParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryCreators, storyId), parameters);
        }
    }
}
