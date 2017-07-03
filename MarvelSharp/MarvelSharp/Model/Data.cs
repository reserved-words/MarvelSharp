
// ReSharper disable once CheckNamespace
namespace MarvelSharp
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
