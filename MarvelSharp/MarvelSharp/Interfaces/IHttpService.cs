using System.Threading.Tasks;

namespace MarvelSharp.Interfaces
{
    internal interface IHttpService
    {
        Task<string> GetAsync(string url);
    }
}
