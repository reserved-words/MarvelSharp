using System;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class ItemBase
    {
        public int? Id { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string ResourceUri { get; set; }
        public Image Thumbnail { get; set; }
    }
}
