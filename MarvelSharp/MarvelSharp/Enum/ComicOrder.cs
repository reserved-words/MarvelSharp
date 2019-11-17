using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Comic sort options
    /// </summary>
    public enum ComicOrder
    {
        /// <summary>
        /// Sort in ascending Final Order Cut-off Date order
        /// </summary>
        [StringValue(nameof(OrderByFocDateAsc))]
        FocDateAscending,
        /// <summary>
        /// Sort in ascending On Sale Date order
        /// </summary>
        [StringValue(nameof(OrderByOnSaleDateAsc))]
        OnSaleDateAscending,
        /// <summary>
        /// Sort in ascending Title order
        /// </summary>
        [StringValue(nameof(OrderByTitleAsc))]
        TitleAscending,
        /// <summary>
        /// Sort in ascending Issue Number order
        /// </summary>
        [StringValue(nameof(OrderByIssueNoAsc))]
        IssueNumberAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Final Order Cut-off Date order
        /// </summary>
        [StringValue(nameof(OrderByFocDateDesc))]
        FocDateDescending,
        /// <summary>
        /// Sort in descending On Sale Date order
        /// </summary>
        [StringValue(nameof(OrderByOnSaleDateDesc))]
        OnSaleDateDescending,
        /// <summary>
        /// Sort in descending Title order
        /// </summary>
        [StringValue(nameof(OrderByTitleDesc))]
        TitleDescending,
        /// <summary>
        /// Sort in descending Issue Number order
        /// </summary>
        [StringValue(nameof(OrderByIssueNoDesc))]
        IssueNumberDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
