using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class RequestDetails
    {
        public RequestDetails(int fetchType, int page, RequestDetails previousRequest)
        {
            FetchType = fetchType;
            Page = page;
            PreviousRequest = previousRequest;
        }

        public RequestDetails(int fetchType, int page, int itemType, int itemId, string itemName, RequestDetails previousRequest)
            : this(fetchType, page, previousRequest)
        {
            ItemType = itemType;
            ItemId = itemId;
            ItemName = itemName;
        }

        public int FetchType { get; private set; }
        public int Page { get; private set; }
        public int ItemType { get; private set; }
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public RequestDetails PreviousRequest { get; private set; }
    }
}
