using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class ItemCollection
    {
        public ItemCollection()
        {
            Items = new List<ItemSummary>();
        }

        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<ItemSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
