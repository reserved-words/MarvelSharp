using MarvelSharp.Parameters;

namespace MarvelSharp.Interfaces
{
    internal interface IUrlBuilder
    {
        string BuildUrl(string apiPublicKey, string apiPrivateKey, string urlSuffix, ParametersBase parameters = null);
    }
}
