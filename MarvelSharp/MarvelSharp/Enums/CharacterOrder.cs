using MarvelSharp.Attributes;

namespace MarvelSharp.Enums
{
    public enum CharacterOrder
    {
        [StringValue("name")]
        NameAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-name")]
        NameDescending,
        [StringValue("-descending")]
        ModifiedDescending
    }
}
