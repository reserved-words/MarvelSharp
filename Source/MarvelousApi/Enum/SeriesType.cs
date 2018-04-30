using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Series type options
    /// </summary>
    public enum SeriesType
    {
        /// <summary>
        /// Collection series
        /// </summary>
        [StringValue(nameof(MarvelApiResources.SeriesTypeCollection))]
        Collection,
        /// <summary>
        /// One shot series
        /// </summary>
        [StringValue(nameof(MarvelApiResources.SeriesTypeOneShot))]
        OneShot,
        /// <summary>
        /// Limited series
        /// </summary>
        [StringValue(nameof(MarvelApiResources.SeriesTypeLimited))]
        Limited,
        /// <summary>
        /// Ongoing series
        /// </summary>
        [StringValue(nameof(MarvelApiResources.SeriesTypeOngoing))]
        Ongoing
    }
}
