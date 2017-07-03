using MarvelSharp.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum CreatorOrder
    {
        [StringValue("lastName")]
        LastNameAscending,
        [StringValue("firstName")]
        FirstNameAscending,
        [StringValue("middleName")]
        MiddleNameAscending,
        [StringValue("suffix")]
        SuffixAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-lastName")]
        LastNameDescending,
        [StringValue("-firstName")]
        FirstNameDescending,
        [StringValue("-middleName")]
        MiddleNameDescending,
        [StringValue("-suffix")]
        SuffixDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
