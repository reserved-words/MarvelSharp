using MarvelSharp.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum StoryOrder
    {
        [StringValue("id")]
        IdAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-id")]
        IdDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
