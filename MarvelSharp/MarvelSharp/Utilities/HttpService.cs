using MarvelSharp.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarvelSharp.Utilities
{
    internal class HttpService : IHttpService
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
