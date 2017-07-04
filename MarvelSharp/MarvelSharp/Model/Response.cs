
namespace MarvelSharp.Model
{
    public class Response<T>
    {
        /// <summary>
        /// If false, the Marvel Comics API did not return an error code.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The HTTP status code of the returned result.
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// A string description of the call status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The copyright notice for the returned result.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// The attribution notice for this result. Please display either this notice or the contents of the attributionHTML field on all screens which contain data from the Marvel Comics API.
        /// </summary>
        public string AttributionText { get; set; }

        /// <summary>
        /// An HTML representation of the attribution notice for this result. Please display either this notice or the contents of the attributionText field on all screens which contain data from the Marvel Comics API.
        /// </summary>
        public string AttributionHtml { get; set; }

        /// <summary>
        /// The results returned by the call.
        /// </summary>
        public Data<T> Data { get; set; }

        /// <summary>
        /// A digest value of the content returned by the call.
        /// </summary>
        public string ETag { get; set; }
    }
}
