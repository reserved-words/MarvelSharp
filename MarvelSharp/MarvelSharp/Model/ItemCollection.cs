using System.Collections.Generic;

namespace MarvelSharp.Model
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
