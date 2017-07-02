using MarvelSharp.Attributes;

namespace MarvelSharp.Enums
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
