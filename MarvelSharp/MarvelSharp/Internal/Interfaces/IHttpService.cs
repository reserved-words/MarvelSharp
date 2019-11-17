using System.Threading.Tasks;

namespace MarvelSharp.Internal.Interfaces
{
    internal interface IHttpService
    {
        Task<string> GetAsync(string url);
    }
}
