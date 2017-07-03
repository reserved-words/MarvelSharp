using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class Character : ItemBase
    {
        public Character()
        {
            Urls = new List<Url>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Url> Urls { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Stories { get; set; }
        public ItemCollection Events { get; set; }

        public override string ToString() => Name;
    }
}
