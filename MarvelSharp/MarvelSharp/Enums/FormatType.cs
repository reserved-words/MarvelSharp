using MarvelSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Enums
{
    public enum FormatType
    {
        [StringValue("comic")]
        Comic,
        [StringValue("collection")]
        Collection
    }
}
