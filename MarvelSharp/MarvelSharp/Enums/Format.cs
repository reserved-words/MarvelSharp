using MarvelSharp.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
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
