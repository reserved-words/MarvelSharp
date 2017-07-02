using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests.ConsoleApp
{
    public class RequestDetails
    {
        public RequestDetails(int fetchType, string fetchStartingWith, DateTime? fetchModifiedSince, int page, RequestDetails previousRequest)
        {
            FetchType = fetchType;
            FetchStartingWith = fetchStartingWith;
            FetchModifiedSince = fetchModifiedSince;
            Page = page;
            PreviousRequest = previousRequest;
        }

        public RequestDetails(int fetchType, string fetchStartingWith, DateTime? fetchModifiedSince, int page, int itemType, int itemId, string itemName, RequestDetails previousRequest)
            : this(fetchType, fetchStartingWith, fetchModifiedSince, page, previousRequest)
        {
            ItemType = itemType;
            ItemId = itemId;
            ItemName = itemName;
        }

        public int FetchType { get; }
        public string FetchStartingWith { get; }
        public DateTime? FetchModifiedSince { get; }
        public int Page { get; }
        public int ItemType { get; }
        public int ItemId { get; }
        public string ItemName { get; }
        public RequestDetails PreviousRequest { get; }
    }
}
