using System.Collections.Generic;

namespace MarvelSharp.Internal.Interfaces
{
    internal interface ICriteria
    {
        Dictionary<string, string> ToDictionary();
    }
}
