using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Comic sort options
    /// </summary>
    public enum ComicOrder
    {
        /// <summary>
        /// Sort in ascending Final Order Cut-off Date order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByFocDateAsc))]
        FocDateAscending,
        /// <summary>
        /// Sort in ascending On Sale Date order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByOnSaleDateAsc))]
        OnSaleDateAscending,
        /// <summary>
        /// Sort in ascending Title order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByTitleAsc))]
        TitleAscending,
        /// <summary>
        /// Sort in ascending Issue Number order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByIssueNoAsc))]
        IssueNumberAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Final Order Cut-off Date order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByFocDateDesc))]
        FocDateDescending,
        /// <summary>
        /// Sort in descending On Sale Date order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByOnSaleDateDesc))]
        OnSaleDateDescending,
        /// <summary>
        /// Sort in descending Title order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByTitleDesc))]
        TitleDescending,
        /// <summary>
        /// Sort in descending Issue Number order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByIssueNoDesc))]
        IssueNumberDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
