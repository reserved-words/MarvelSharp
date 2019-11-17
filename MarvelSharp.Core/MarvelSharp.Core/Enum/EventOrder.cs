using MarvelSharp.Internal.Attributes;
using static MarvelSharp.Core.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Event sort options
    /// </summary>
    public enum EventOrder
    {
        /// <summary>
        /// Sort in ascending Name order
        /// </summary>
        [StringValue(nameof(OrderByNameAsc))]
        NameAscending,
        /// <summary>
        /// Sort in ascending order of the date of publication of the first issue in the event
        /// </summary>
        [StringValue(nameof(OrderByStartDateAsc))]
        StartDateAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Name order
        /// </summary>
        [StringValue(nameof(OrderByNameDesc))]
        NameDescending,
        /// <summary>
        /// Sort in descending order of the date of publication of the first issue in the event
        /// </summary>
        [StringValue(nameof(OrderByStartDateDesc))]
        StartDateDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
