using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Event sort options
    /// </summary>
    public enum EventOrder
    {
        /// <summary>
        /// Sort in ascending Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByNameAsc))]
        NameAscending,
        /// <summary>
        /// Sort in ascending order of the date of publication of the first issue in the event
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByStartDateAsc))]
        StartDateAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByNameDesc))]
        NameDescending,
        /// <summary>
        /// Sort in descending order of the date of publication of the first issue in the event
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByStartDateDesc))]
        StartDateDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
