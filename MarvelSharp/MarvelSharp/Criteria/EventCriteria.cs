using System.Collections.Generic;

namespace MarvelSharp.Criteria
{
    /// <summary>
    /// A class representing criteria by which to filter events.
    /// </summary>
    public class EventCriteria : BaseCriteria
    {
        /// <summary>
        /// Initializes an instance of the EventCriteria class
        /// </summary>
        public EventCriteria()
        {
            Comics = new List<int>();
            Series = new List<int>();
            Stories = new List<int>();
            OrderBy = new List<EventOrder>();
        }

        /// <summary>
        /// Return only events which match the specified name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return events with names that begin with the specified string (e.g. Sp).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Return only events which feature work by creators specified by a list of IDs.
        /// </summary>
        public List<int> Creators { get; set; }

        /// <summary>
        /// Return only events which feature characters specified by a list of IDs.
        /// </summary>
        public List<int> Characters { get; set; }

        /// <summary>
        /// Return only events which are part of series specified by a list of IDs.
        /// </summary>
        public List<int> Series { get; set; }

        /// <summary>
        /// Return only events which take place in comics specified by a list of IDs.
        /// </summary>
        public List<int> Comics { get; set; }

        /// <summary>
        /// Return only events which take place in stories specified by a list of IDs.
        /// </summary>
        public List<int> Stories { get; set; }

        /// <summary>
        /// Order the result set by the selected fields. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public List<EventOrder> OrderBy { get; set; }
    }
}
