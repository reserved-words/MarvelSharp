using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Model
{
    public class Series : ItemBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public List<Url> Urls { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string Rating { get; set; }
        public string Type { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public Image Thumbnail { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Stories { get; set; }
        public ItemCollection Events { get; set; }
        public ItemCollection Characters { get; set; }
        public ItemCollection Creators { get; set; }
        public Item Next { get; set; }
        public Item Previous { get; set; }

        public override string ToString() => Title;
    }
}
