using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Series sort options
    /// </summary>
    public enum SeriesOrder
    {
        /// <summary>
        /// Sort in ascending Title order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByTitleAsc))]
        TitleAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in ascending order of the year the series was first published
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByStartYearAsc))]
        StartYearAscending,
        /// <summary>
        /// Sort in descending Title order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByTitleDesc))]
        TitleDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending,
        /// <summary>
        /// Sort in descending order of the year the series was first published
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByStartYearDesc))]
        StartYearDescending
    }
}
