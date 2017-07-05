using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Creator sort options
    /// </summary>
    public enum CreatorOrder
    {
        /// <summary>
        /// Sort in ascending Last Name order
        /// </summary>
        [StringValue(nameof(OrderByLastNameAsc))]
        LastNameAscending,
        /// <summary>
        /// Sort in ascending First Name order
        /// </summary>
        [StringValue(nameof(OrderByFirstNameAsc))]
        FirstNameAscending,
        /// <summary>
        /// Sort in ascending Middle Name order
        /// </summary>
        [StringValue(nameof(OrderByMiddleNameAsc))]
        MiddleNameAscending,
        /// <summary>
        /// Sort in ascending Suffix order (e.g. Jr., Sr.)
        /// </summary>
        [StringValue(nameof(OrderBySuffixAsc))]
        SuffixAscending,
        /// <summary>
        /// Sort in ascending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedAsc))]
        ModifiedAscending,
        /// <summary>
        /// Sort in descending Last Name order
        /// </summary>
        [StringValue(nameof(OrderByLastNameDesc))]
        LastNameDescending,
        /// <summary>
        /// Sort in descending First Name order
        /// </summary>
        [StringValue(nameof(OrderByFirstNameDesc))]
        FirstNameDescending,
        /// <summary>
        /// Sort in descending Middle Name order
        /// </summary>
        [StringValue(nameof(OrderByMiddleNameDesc))]
        MiddleNameDescending,
        /// <summary>
        /// Sort in descending Suffix order (e.g. Jr., Sr.)
        /// </summary>
        [StringValue(nameof(OrderBySuffixDesc))]
        SuffixDescending,
        /// <summary>
        /// Sort in descending order of the date the resource was last modified
        /// </summary>
        [StringValue(nameof(OrderByDateModifiedDesc))]
        ModifiedDescending
    }
}
