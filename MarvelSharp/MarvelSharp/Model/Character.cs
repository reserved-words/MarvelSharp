using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Model
{
    public class Character : ItemBase
    {
        public Character()
        {
            Urls = new List<Url>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string ResourceUri { get; set; }
        public List<Url> Urls { get; set; }
        public Image Thumbnail { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Stories { get; set; }
        public ItemCollection Events { get; set; }

        public override string ToString() => Name;
    }
}
