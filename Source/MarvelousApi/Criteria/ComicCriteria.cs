using System.Collections.Generic;
using MarvelousApi.Enum;
using MarvelousApi.Model;

namespace MarvelousApi.Criteria
{

    /// <summary>
    /// A class representing criteria by which to filter comics.
    /// </summary>
    public class ComicCriteria : BaseCriteria
    {
        /// <summary>
        /// Initializes an instance of the ComicCriteria class
        /// </summary>
        public ComicCriteria()
        {
            Creators = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
            Collaborators = new List<int>();
            OrderBy = new List<ComicOrder>();
        }
        
        /// <summary>
        /// Filter by the issue format.
        /// </summary>
        public Format? Format { get; set; }

        /// <summary>
        /// Filter by the issue format type. 
        /// </summary>
        public FormatType? FormatType { get; set; }

        /// <summary>
        /// Exclude variants (alternate covers, secondary printings, director's cuts, etc.) from the result set.
        /// </summary>
        public bool? NoVariants { get; set; }

        /// <summary>
        /// Return comics within a predefined date range.
        /// </summary>
        public DateDescriptor? DateDescriptor { get; set; }

        /// <summary>
        /// Return comics within a predefined date range.
        /// </summary>
        public DateRange? DateRange { get; set; }

        /// <summary>
        /// Return only issues in series whose title matches the input.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return only issues in series whose title starts with the input.
        /// </summary>
        public string TitleStartsWith { get; set; }

        /// <summary>
        /// Return only issues in series whose start year matches the input.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// Return only issues in series whose issue number matches the input.
        /// </summary>
        public int? IssueNumber { get; set; }

        /// <summary>
        /// Filter by diamond code.
        /// </summary>
        public string DiamondCode { get; set; }

        /// <summary>
        /// Filter by digital comic id.
        /// </summary>
        public int? DigitalId { get; set; }

        /// <summary>
        /// Filter by UPC.
        /// </summary>
        public string Upc { get; set; }

        /// <summary>
        /// Filter by ISBN.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Filter by EAN.
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Filter by ISSN.
        /// </summary>
        public string Issn { get; set; }

        /// <summary>
        /// Include only results which are available digitally.
        /// </summary>
        public bool? HasDigitalIssue { get; set; }

        /// <summary>
        /// Return only comics which feature work by creators specified by a list of IDs.
        /// </summary>
        public List<int> Creators { get; set; }

        /// <summary>
        /// Return only comics which are part of series specified by a list of IDs.
        /// </summary>
        public List<int> Series { get; set; }

        /// <summary>
        /// Return only comics which take place in events specified by a list of IDs.
        /// </summary>
        public List<int> Events { get; set; }

        /// <summary>
        /// Return only comics which contain stories specified by a list of IDs.
        /// </summary>
        public List<int> Stories { get; set; }

        /// <summary>
        /// Return only comics in which characters specified by a list of IDs appear together (for example in which BOTH Spider-Man and Wolverine appear). 
        /// </summary>
        public List<int> SharedAppearances { get; set; }

        /// <summary>
        /// Return only comics in which creators specified by a list of IDs worked together (for example in which BOTH Stan Lee and Jack Kirby did work).
        /// </summary>
        public List<int> Collaborators { get; set; }

        /// <summary>
        /// Order the result set by the selected fields. Multiple values are given priority in the order in which they are passed.
        /// </summary>
        public List<ComicOrder> OrderBy { get; set; }
    }
}
