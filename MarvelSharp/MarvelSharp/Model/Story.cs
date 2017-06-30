using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Model
{
    public class Story : ItemBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Modified { get; set; }
        public Image Thumbnail { get; set; }
        public ItemCollection Creators { get; set; }
        public ItemCollection Characters { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Events { get; set; }
        public Item OriginalIssue { get; set; }

        public override string ToString() => Title;
    }
}
