using MarvelSharp.Enums;
using MarvelSharp.Model;
using System;
using System.Collections.Generic;

namespace MarvelSharp.Parameters
{
    public class ComicParameters : ParametersBase
    {
        public ComicParameters()
        {
            Creators = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
            Collaborators = new List<int>();
        }

        public Format? Format { get; set; }
        public FormatType? FormatType { get; set; }
        public bool? NoVariants { get; set; }
        public DateDescriptor? DateDescriptor { get; set; }
        public DateRange? DateRange { get; set; }
        public string Title { get; set; }
        public string TitleStartsWith { get; set; }
        public int? StartYear { get; set; }
        public int? IssueNumber { get; set; }
        public string DiamondCode { get; set; }
        public int? DigitalId { get; set; }
        public string Upc { get; set; }
        public string Isbn { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public bool? HasDigitalIssue { get; set; }
        public DateTime? ModifiedSince { get; set; }
        public List<int> Creators { get; set; }
        public List<int> Series { get; set; }
        public List<int> Events { get; set; }
        public List<int> Stories { get; set; }
        public int? SharedAppearances { get; set; }
        public List<int> Collaborators { get; set; }
        public ComicOrder? OrderBy { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
