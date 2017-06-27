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
    public class ComicService : BaseService<Comic>
    {
        public ComicService(string apiPublicKey, string apiPrivateKey)
            :base(ServiceLocator.HttpService, ServiceLocator.ComicParser, ServiceLocator.UrlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        internal ComicService(IHttpService httpService, IParser<Comic> parser, IUrlBuilder urlBuilder, string apiPublicKey, string apiPrivateKey)
            :base(httpService, parser, urlBuilder, apiPublicKey, apiPrivateKey)
        {
        }

        public async Task<Response<List<Comic>>> GetAllAsync(ComicParameters parameters = null)
        {
            return await GetList(MarvelApi.GetAllComics, parameters);
        }

        public async Task<Response<Comic>> GetByIdAsync(int comicId)
        {
            return await GetSingle(string.Format(MarvelApi.GetComic, comicId), null);
        }

        public async Task<Response<List<Comic>>> GetByCharacterAsync(int characterId, ComicParameters parameters = null)
        {
            return await GetList(string.Format(MarvelApi.GetCharacterComics, characterId), parameters);
        }
    }
}
