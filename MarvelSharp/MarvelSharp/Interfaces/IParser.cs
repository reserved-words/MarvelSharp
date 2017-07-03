using System.Collections.Generic;

namespace MarvelSharp.Interfaces
{
    internal interface IParser<T>
    {
        List<T> ParseList(dynamic results);
        T ParseSingle(dynamic results);
        Response<T1> GetResponse<T1>(dynamic parsed);
    }
}
