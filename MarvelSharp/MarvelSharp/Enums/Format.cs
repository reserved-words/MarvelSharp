using MarvelSharp.Attributes;

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
