using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Creator sort options
    /// </summary>
    public enum CreatorOrder
    {
        /// <summary>
        /// Sort in ascending Last Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByLastNameAsc))]
        LastNameAscending,
        /// <summary>
        /// Sort in ascending First Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByFirstNameAsc))]
        FirstNameAscending,
        /// <summary>
        /// Sort in ascending Middle Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByMiddleNameAsc))]
        MiddleNameAscending,
        /// <summary>
        /// Sort in ascending Suffix order (e.g. Jr., Sr.)
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderBySuffixAsc))]
        SuffixAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Last Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByLastNameDesc))]
        LastNameDescending,
        /// <summary>
        /// Sort in descending First Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByFirstNameDesc))]
        FirstNameDescending,
        /// <summary>
        /// Sort in descending Middle Name order
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByMiddleNameDesc))]
        MiddleNameDescending,
        /// <summary>
        /// Sort in descending Suffix order (e.g. Jr., Sr.)
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderBySuffixDesc))]
        SuffixDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(MarvelApiResources.OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
