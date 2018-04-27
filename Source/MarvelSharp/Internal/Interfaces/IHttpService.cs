using System.Threading.Tasks;

namespace MarvelSharp.Internal.Interfaces
{
	public interface IHttpService
    {
        Task<string> GetAsync(string url);
    }
}
