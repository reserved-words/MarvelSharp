using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Story sort options
    /// </summary>
    public enum StoryOrder
    {
        /// <summary>
        /// Sort in ascending ID order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByIdAsc))]
        IdAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending ID order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByIdDesc))]
        IdDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
