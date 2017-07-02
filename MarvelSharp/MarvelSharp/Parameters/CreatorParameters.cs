using System.Collections.Generic;
using MarvelSharp.Enums;

namespace MarvelSharp.Parameters
{
    public class CreatorParameters : ParametersBase
    {
        public CreatorParameters()
        {
            Comics = new List<int>();
            Series = new List<int>();
            Events = new List<int>();
            Stories = new List<int>();
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string NameStartsWith { get; set; }
        public string FirstNameStartsWith { get; set; }
        public string MiddleNameStartsWith { get; set; }
        public string LastNameStartsWith { get; set; }
        public List<int> Comics { get; set; }
        public List<int> Series { get; set; }
        public List<int> Events { get; set; }
        public List<int> Stories { get; set; }
        public CreatorOrder OrderBy { get; set; }
    }
}
