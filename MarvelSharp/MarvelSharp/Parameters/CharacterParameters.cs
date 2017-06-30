using MarvelSharp.Enums;
using System;
using System.Collections.Generic;

namespace MarvelSharp.Parameters
{
    public class CharacterParameters : ParametersBase
    {
        public CharacterParameters()
        {
            Comics = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
        }
        
        public string Name { get; set; }
        public string NameStartsWith { get; set; }
        public List<int> Comics { get; set; }
        public List<int> Series { get; set; }
        public List<int> Events { get; set; }
        public List<int> Stories { get; set; }
        public CharacterOrder? OrderBy { get; set; }
    }
}
