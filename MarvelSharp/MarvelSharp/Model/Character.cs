using System.Collections.Generic;

namespace MarvelSharp.Model
{
    public class Character : ItemBase
    {
        public Character()
        {
            Urls = new List<Url>();
        }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short bio or description of the character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// A resource list containing comics which feature this character.
        /// </summary>
        public ItemCollection Comics { get; set; }

        /// <summary>
        /// A resource list of series in which this character appears.
        /// </summary>
        public ItemCollection Series { get; set; }

        /// <summary>
        /// A resource list of stories in which this character appears.
        /// </summary>
        public ItemCollection Stories { get; set; }

        /// <summary>
        /// A resource list of events in which this character appears.
        /// </summary>
        public ItemCollection Events { get; set; }

        public override string ToString() => Name;
    }
}
