using MarvelSharp.Internal.Attributes;
using static MarvelSharp.Core.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Series sort options
    /// </summary>
    public enum SeriesOrder
    {
        /// <summary>
        /// Sort in ascending Title order
        /// </summary>
        [StringValue(nameof(OrderByTitleAsc))]
        TitleAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in ascending order of the year the series was first published
        /// </summary>
        [StringValue(nameof(OrderByStartYearAsc))]
        StartYearAscending,
        /// <summary>
        /// Sort in descending Title order
        /// </summary>
        [StringValue(nameof(OrderByTitleDesc))]
        TitleDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending,
        /// <summary>
        /// Sort in descending order of the year the series was first published
        /// </summary>
        [StringValue(nameof(OrderByStartYearDesc))]
        StartYearDescending
    }
}
