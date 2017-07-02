using MarvelSharp.Attributes;

namespace MarvelSharp.Enums
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
