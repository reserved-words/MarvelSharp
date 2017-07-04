
namespace MarvelSharp.Model
{
    public class Story : ItemBase
    {
        /// <summary>
        /// The story title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A short description of the story.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The story type e.g. interior story, cover, text story.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A resource list of creators who worked on this story.
        /// </summary>
        public ItemCollection Creators { get; set; }

        /// <summary>
        /// A resource list of characters which appear in this story.
        /// </summary>
        public ItemCollection Characters { get; set; }

        /// <summary>
        /// A resource list containing series in which this story appears.
        /// </summary>
        public ItemCollection Series { get; set; }

        /// <summary>
        /// A resource list containing comics in which this story takes place.
        /// </summary>
        public ItemCollection Comics { get; set; }

        /// <summary>
        /// A resource list of the events in which this story appears.
        /// </summary>
        public ItemCollection Events { get; set; }

        /// <summary>
        /// A summary representation of the issue in which this story was originally published.
        /// </summary>
        public ItemSummary OriginalIssue { get; set; }

        public override string ToString() => Title;
    }
}
