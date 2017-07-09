using System.Collections.Generic;
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Interfaces
{
    internal interface IParser<T>
    {
        List<T> ParseList(dynamic results);
        T ParseSingle(dynamic results);
        Response<T1> GetResponse<T1>(dynamic parsed);
    }
}
