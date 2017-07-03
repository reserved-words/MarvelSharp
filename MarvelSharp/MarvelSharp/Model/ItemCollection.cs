using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class ItemCollection
    {
        public ItemCollection()
        {
            Items = new List<Item>();
        }

        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<Item> Items { get; set; }
        public int Returned { get; set; }
    }
}
