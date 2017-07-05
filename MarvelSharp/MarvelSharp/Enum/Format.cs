using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Comic format options
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Comic format
        /// </summary>
        [StringValue(nameof(FormatComic))]
        Comic,
        /// <summary>
        /// Magazine format
        /// </summary>
        [StringValue(nameof(FormatMagazine))]
        Magazine,
        /// <summary>
        /// Trade paperback format
        /// </summary>
        [StringValue(nameof(FormatTradePaperback))]
        TradePaperback,
        /// <summary>
        /// Hardcover format
        /// </summary>
        [StringValue(nameof(FormatHardcover))]
        Hardcover,
        /// <summary>
        /// Digest format
        /// </summary>
        [StringValue(nameof(FormatDigest))]
        Digest,
        /// <summary>
        /// Graphic novel format
        /// </summary>
        [StringValue(nameof(FormatGraphicNovel))]
        GraphicNovel,
        /// <summary>
        /// Digital comic format
        /// </summary>
        [StringValue(nameof(FormatDigitalComic))]
        DigitalComic,
        /// <summary>
        /// Infinite comic format
        /// </summary>
        [StringValue(nameof(FormatInfiniteComic))]
        InfiniteComic
    }
}
