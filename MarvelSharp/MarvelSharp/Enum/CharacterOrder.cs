using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Character sort options
    /// </summary>
    public enum CharacterOrder
    {
        /// <summary>
        /// Sort in ascending Name order
        /// </summary>
        [StringValue(nameof(OrderByNameAsc))]
        NameAscending,
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
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
