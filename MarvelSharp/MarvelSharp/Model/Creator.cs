using System.Collections.Generic;

namespace MarvelSharp.Model
{
    public class Creator : ItemBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Stories { get; set; }
        public ItemCollection Events { get; set; }
        public List<Url> Urls { get; set; }

        public override string ToString() => FullName;
    }
}
