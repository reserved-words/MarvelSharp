using System.Collections.Generic;

namespace MarvelSharp.Interfaces
{
    public interface IParameters
    {
        Dictionary<string, string> ToDictionary();
    }
}
