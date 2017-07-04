using MarvelSharp.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum SeriesType
    {
        [StringValue("collection")]
        Collection,
        [StringValue("one shot")]
        OneShot,
        [StringValue("limited")]
        Limited,
        [StringValue("ongoing")]
        Ongoing
    }
}
