using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Date descriptor options
    /// </summary>
    public enum DateDescriptor
    {
        /// <summary>
        /// Return comics published last week
        /// </summary>
        [StringValue(nameof(DateDescriptorLastWeek))]
        LastWeek,
        /// <summary>
        /// Return comics published this week
        /// </summary>
        [StringValue(nameof(DateDescriptorThisWeek))]
        ThisWeek,
        /// <summary>
        /// Return comics to be published last week
        /// </summary>
        [StringValue(nameof(DateDescriptorNextWeek))]
        NextWeek,
        /// <summary>
        /// Return comics published this month
        /// </summary>
        [StringValue(nameof(DateDescriptorThisMonth))]
        ThisMonth
    }
}
