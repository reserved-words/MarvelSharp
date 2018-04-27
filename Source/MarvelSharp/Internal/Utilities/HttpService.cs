using System.Net.Http;
using System.Threading.Tasks;
using MarvelSharp.Internal.Interfaces;

namespace MarvelSharp.Internal.Utilities
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
