using MarvelSharp.Internal.Attributes;
using static MarvelSharp.Core.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Story sort options
    /// </summary>
    public enum StoryOrder
    {
        /// <summary>
        /// Sort in ascending ID order
        /// </summary>
        [StringValue(nameof(OrderByIdAsc))]
        IdAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending ID order
        /// </summary>
        [StringValue(nameof(OrderByIdDesc))]
        IdDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
