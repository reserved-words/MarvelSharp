using MarvelSharp.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
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
