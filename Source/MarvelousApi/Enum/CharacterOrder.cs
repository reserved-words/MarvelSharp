using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Character sort options
    /// </summary>
    public enum CharacterOrder
    {
        /// <summary>
        /// Sort in ascending Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByNameAsc))]
        NameAscending,
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
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
