using System.Collections.Generic;
using MarvelSharp.Enums;

namespace MarvelSharp.Parameters
{
    public class StoryParameters : ParametersBase
    {
        public StoryParameters()
        {
            Comics = new List<int>();
            Characters = new List<int>();
            Creators = new List<int>();
            Events = new List<int>();
            Series = new List<int>();
        }

        public List<int> Characters { get; set; }
        public List<int> Comics { get; set; }
        public List<int> Creators { get; set; }
        public List<int> Events { get; set; }
        public List<int> Series { get; set; }
        public StoryOrder? OrderBy { get; set; }
    }
}
