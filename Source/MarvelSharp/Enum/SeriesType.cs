using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Series type options
    /// </summary>
    public enum SeriesType
    {
        /// <summary>
        /// Collection series
        /// </summary>
        [StringValue(nameof(SeriesTypeCollection))]
        Collection,
        /// <summary>
        /// One shot series
        /// </summary>
        [StringValue(nameof(SeriesTypeOneShot))]
        OneShot,
        /// <summary>
        /// Limited series
        /// </summary>
        [StringValue(nameof(SeriesTypeLimited))]
        Limited,
        /// <summary>
        /// Ongoing series
        /// </summary>
        [StringValue(nameof(SeriesTypeOngoing))]
        Ongoing
    }
}
