
namespace MarvelSharp.Interfaces
{
    internal interface IUrlBuilder
    {
        string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, IParameters parameters = null);
    }
}
