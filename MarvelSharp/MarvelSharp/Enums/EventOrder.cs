using MarvelSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Enums
{
    public enum EventOrder
    {
        [StringValue("name")]
        NameAscending,
        [StringValue("startDate")]
        StartDateAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-name")]
        NameDescending,
        [StringValue("-startDate")]
        StartDateDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
