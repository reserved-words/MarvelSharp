using MarvelSharp.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public enum DateDescriptor
    {
        [StringValue("lastWeek")]
        LastWeek,
        [StringValue("thisWeek")]
        ThisWeek,
        [StringValue("nextWeek")]
        NextWeek,
        [StringValue("thisMonth")]
        ThisMonth
    }
}
