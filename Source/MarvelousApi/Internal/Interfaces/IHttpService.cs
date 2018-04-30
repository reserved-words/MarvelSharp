using System.Threading.Tasks;

namespace MarvelousApi.Internal.Interfaces
{
	public interface IHttpService
    {
        Task<string> GetAsync(string url);
    }
}
