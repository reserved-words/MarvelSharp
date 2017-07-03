using MarvelSharp.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum ComicOrder
    {
        [StringValue("focDate")]
        FocDateAscending,
        [StringValue("onsaleDate")]
        OnSaleDateAscending,
        [StringValue("title")]
        TitleAscending,
        [StringValue("issueNumber")]
        IssueNumberAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-focDate")]
        FocDateDescending,
        [StringValue("-onsaleDate")]
        OnSaleDateDescending,
        [StringValue("-title")]
        TitleDescending,
        [StringValue("-issueNumber")]
        IssueNumberDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
