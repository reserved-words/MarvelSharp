using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelSharp.Services
{
    /// <summary>
    /// A service providing details of Marvel comics
    /// </summary>
    public class ComicService : BaseService<Comic>
    {
        /// <summary>
        /// Initializes a new instance of the ComicService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public ComicService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.ComicParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal ComicService(IHttpService httpService, IParser<Comic> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        /// <summary>
        /// Fetches a list of comics, with optional filters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetAllAsync(ComicParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllComics, parameters);
        }

        /// <summary>
        /// Fetches details for the specified comic
        /// </summary>
        /// <param name="comicId"></param>
        /// <returns></returns>
        public async Task<Response<Comic>> GetByIdAsync(int comicId)
        {
            return await GetSingle(string.Format(MarvelApi.GetComic, comicId), null);
        }

        /// <summary>
        /// Fetches a list of comics containing the specified character, with optional filters
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByCharacterAsync(int characterId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterComics, characterId), parameters);
        }

        /// <summary>
        /// Fetches a list of comics in which the work of the specified creator appears, with optional filters
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByCreatorAsync(int creatorId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCreatorComics, creatorId), parameters);
        }

        /// <summary>
        /// Fetches a list of comics that take place during the specified event, with optional filters
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByEventAsync(int eventId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetEventComics, eventId), parameters);
        }

        /// <summary>
        /// Fetches a list of comics that are published as part of the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetBySeriesAsync(int seriesId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetSeriesComics, seriesId), parameters);
        }

        /// <summary>
        /// Fetches a list of comics in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetByStoryAsync(int storyId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetStoryComics, storyId), parameters);
        }
    }
}
