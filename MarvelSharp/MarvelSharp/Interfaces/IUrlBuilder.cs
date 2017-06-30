
namespace MarvelSharp.Interfaces
{
    internal interface IUrlBuilder
    {
        string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, int? limit = null, int? offset = null, IParameters parameters = null);
    }
}
