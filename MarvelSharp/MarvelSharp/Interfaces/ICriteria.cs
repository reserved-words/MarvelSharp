using System.Collections.Generic;

namespace MarvelSharp.Interfaces
{
    public interface ICriteria
    {
        Dictionary<string, string> ToDictionary();
    }
}
