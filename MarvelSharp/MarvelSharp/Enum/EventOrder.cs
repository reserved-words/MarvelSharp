using MarvelSharp.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum EventOrder
    {
        [StringValue("name")]
        NameAscending,
        [StringValue("startDate")]
        StartDateAscending,
        [StringValue("modified")]
        ModifiedAscending,
        [StringValue("-name")]
        NameDescending,
        [StringValue("-startDate")]
        StartDateDescending,
        [StringValue("-modified")]
        ModifiedDescending
    }
}
