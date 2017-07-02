using System.Collections.Generic;
using MarvelSharp.Enums;

namespace MarvelSharp.Parameters
{
    public class SeriesParameters : ParametersBase
    {
        public SeriesParameters()
        {
            Comics = new List<int>();
            Characters = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
            Creators = new List<int>();
            Contains = new List<Format>();
        }

        public string Title { get; set; }
        public string TitleStartsWith { get; set; }
        public int? StartYear { get; set; }
        public List<int> Characters { get; set; }
        public List<int> Comics { get; set; }
        public List<int> Creators { get; set; }
        public List<int> Events { get; set; }
        public List<int> Stories { get; set; }
        public SeriesType? SeriesType { get; set; }
        public List<Format> Contains { get; set; }
        public SeriesOrder? OrderBy { get; set; }
    }
}
