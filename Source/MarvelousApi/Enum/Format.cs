using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Comic format options
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Comic format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatComic))]
        Comic,
        /// <summary>
        /// Magazine format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatMagazine))]
        Magazine,
        /// <summary>
        /// Trade paperback format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatTradePaperback))]
        TradePaperback,
        /// <summary>
        /// Hardcover format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatHardcover))]
        Hardcover,
        /// <summary>
        /// Digest format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatDigest))]
        Digest,
        /// <summary>
        /// Graphic novel format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatGraphicNovel))]
        GraphicNovel,
        /// <summary>
        /// Digital comic format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatDigitalComic))]
        DigitalComic,
        /// <summary>
        /// Infinite comic format
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatInfiniteComic))]
        InfiniteComic
    }
}
