using MarvelSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Enums
{
    public enum DateDescriptor
    {
        [StringValue("lastWeek")]
        LastWeek,
        [StringValue("thisWeek")]
        ThisWeek,
        [StringValue("nextWeek")]
        NextWeek,
        [StringValue("thisMonth")]
        ThisMonth
    }
}
