using System.Collections.Generic;

namespace MarvelSharp.Criteria
{
    /// <summary>
    /// A class representing criteria by which to filter characters.
    /// </summary>
    public class CharacterCriteria : BaseCriteria
    {
        /// <summary>
        /// Initializes an instance of the CharacterCriteria class
        /// </summary>
        public CharacterCriteria()
        {
            Comics = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
            OrderBy = new List<CharacterOrder>();
        }

        /// <summary>
        /// Return only characters matching the specified full character name (e.g. Spider-Man).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return characters with names that begin with the specified string (e.g. Sp).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only characters which appear in comics specified by a list of IDs.
        /// </summary>
        public List<int> Comics { get; set; }

        /// <summary>
        /// Return only characters which appear in series specified by a list of IDs.
        /// </summary>
        public List<int> Series { get; set; }

        /// <summary>
        /// Return only characters which appear in events specified by a list of IDs.
        /// </summary>
        public List<int> Events { get; set; }

        /// <summary>
        /// Return only characters which appear in stories specified by a list of IDs.
        /// </summary>
        public List<int> Stories { get; set; }

        /// <summary>
        /// Order the result set by the selected fields. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public List<CharacterOrder> OrderBy { get; set; }
    }
}
