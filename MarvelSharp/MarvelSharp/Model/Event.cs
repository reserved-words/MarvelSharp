using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class Event : ItemBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Url> Urls { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ItemCollection Comics { get; set; }
        public ItemCollection Stories { get; set; }
        public ItemCollection Series { get; set; }
        public ItemCollection Characters { get; set; }
        public ItemCollection Creators { get; set; }
        public Item Next { get; set; }
        public Item Previous { get; set; }

        public override string ToString() => Title;
    }
}
