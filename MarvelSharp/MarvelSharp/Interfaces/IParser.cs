using MarvelSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Interfaces
{
    public interface IParser<T>
    {
        List<T> ParseList(dynamic results);
        T ParseSingle(dynamic results);
        Response<T1> GetResponse<T1>(dynamic parsed);
    }
}
