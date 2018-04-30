using System.Collections.Generic;
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Interfaces
{
	public interface IParser<T>
    {
        List<T> ParseList(dynamic results);
        T ParseSingle(dynamic results);
        Response<T1> GetResponse<T1>(dynamic parsed);
    }
}
