using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Model
{
    public class Data<T>
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public int? Total { get; set; }
        public int? Count { get; set; }
        public T Result { get; set; }
    }
}
