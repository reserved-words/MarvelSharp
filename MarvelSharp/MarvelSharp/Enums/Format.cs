using MarvelSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Enums
{
    public enum Format
    {
        [StringValue("comic")]
        Comic,
        [StringValue("magazine")]
        Magazine,
        [StringValue("trade paperback")]
        TradePaperback,
        [StringValue("hardcover")]
        Hardcover,
        [StringValue("digest")]
        Digest,
        [StringValue("graphic novel")]
        GraphicNovel,
        [StringValue("digital comic")]
        DigitalComic,
        [StringValue("infinite comic")]
        InfiniteComic
    }
}
