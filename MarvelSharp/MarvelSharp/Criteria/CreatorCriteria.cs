using System.Collections.Generic;

namespace MarvelSharp.Criteria
{
    /// <summary>
    /// A class representing criteria by which to filter creators.
    /// </summary>
    public class CreatorCriteria : BaseCriteria
    {
        /// <summary>
        /// Initializes an instance of the CreatorCriteria class
        /// </summary>
        public CreatorCriteria()
        {
            Comics = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
            OrderBy = new List<CreatorOrder>();
        }

        /// <summary>
        /// Filter by creator first name (e.g. Brian).
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Filter by creator middle name (e.g. Michael).
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Filter by creator last name (e.g. Bendis).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Filter by suffix or honorific (e.g. Jr., Sr.).
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Filter by creator names that match critera (e.g. B, St L).
        /// </summary>
        public string NameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator first names that match critera (e.g. B, St L).
        /// </summary>
        public string FirstNameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator middle names that match critera (e.g. Mi).
        /// </summary>
        public string MiddleNameStartsWith { get; set; }

        /// <summary>
        /// Filter by creator last names that match critera (e.g. Ben).
        /// </summary>
        public string LastNameStartsWith { get; set; }

        /// <summary>
        /// Return only creators who worked on comics specified by a list of IDs.
        /// </summary>
        public List<int> Comics { get; set; }

        /// <summary>
        /// Return only creators who worked on series specified by a list of IDs.
        /// </summary>
        public List<int> Series { get; set; }

        /// <summary>
        /// Return only creators who worked on comics that took place in events specified by a list of IDs.
        /// </summary>
        public List<int> Events { get; set; }

        /// <summary>
        /// Return only creators who worked on stories specified by a list of IDs.
        /// </summary>
        public List<int> Stories { get; set; }

        /// <summary>
        /// Order the result set by the selected fields. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public List<CreatorOrder> OrderBy { get; set; }
    }
}
