using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// A class representing criteria by which to filter stories.
    /// </summary>
    public class StoryCriteria : BaseCriteria
    {
        public StoryCriteria()
        {
            Comics = new List<int>();
            Characters = new List<int>();
            Creators = new List<int>();
            Events = new List<int>();
            Series = new List<int>();
        }

        /// <summary>
        /// Return only stories which feature characters specified by a list of IDs.
        /// </summary>
        public List<int> Characters { get; set; }

        /// <summary>
        /// Return only stories contained in comics specified by a list of IDs.
        /// </summary>
        public List<int> Comics { get; set; }

        /// <summary>
        /// Return only stories which feature work by creators specified by a list of IDs.
        /// </summary>
        public List<int> Creators { get; set; }

        /// <summary>
        /// Return only stories which take place during events specified by a list of IDs.
        /// </summary>
        public List<int> Events { get; set; }

        /// <summary>
        /// Return only stories contained in series speified by a list of IDs.
        /// </summary>
        public List<int> Series { get; set; }

        /// <summary>
        /// Order the result set by the selected fields.
        /// </summary>
        public StoryOrder? OrderBy { get; set; }
    }
}
