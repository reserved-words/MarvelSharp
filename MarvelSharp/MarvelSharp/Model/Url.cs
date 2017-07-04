namespace MarvelSharp.Model
{
    public class Url
    {
        /// <summary>
        /// A text identifier for the URL.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A full URL (including scheme, domain, and path).
        /// </summary>
        public string Value { get; set; }
    }
}
