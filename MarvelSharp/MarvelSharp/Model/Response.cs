
// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public int? Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public Data<T> Data { get; set; }
        public string ETag { get; set; }
    }
}
