namespace MarvelousApi.Model
{
    public class TextObject
    {
        /// <summary>
        /// The canonical type of the text object (e.g. solicit text, preview text, etc.).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The IETF language tag denoting the language the text object is written in.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The text.
        /// </summary>
        public string Text { get; set; }
    }
}
