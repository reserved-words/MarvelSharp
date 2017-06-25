using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Model
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
