
namespace MarvelSharp.Internal.Interfaces
{
    internal interface IUrlBuilder
    {
        string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, int? limit = null, int? offset = null, ICriteria criteria = null);
    }
}
