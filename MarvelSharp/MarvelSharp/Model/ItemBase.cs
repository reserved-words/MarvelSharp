using System;

namespace MarvelSharp.Model
{
    public class ItemBase
    {
        public int? Id { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string ResourceUri { get; set; }
        public Image Thumbnail { get; set; }
    }
}
