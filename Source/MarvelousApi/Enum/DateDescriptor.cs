using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Date descriptor options
    /// </summary>
    public enum DateDescriptor
    {
        /// <summary>
        /// Return comics published last week
        /// </summary>
        [StringValue(nameof(MarvelApiResources.DateDescriptorLastWeek))]
        LastWeek,
        /// <summary>
        /// Return comics published this week
        /// </summary>
        [StringValue(nameof(MarvelApiResources.DateDescriptorThisWeek))]
        ThisWeek,
        /// <summary>
        /// Return comics to be published last week
        /// </summary>
        [StringValue(nameof(MarvelApiResources.DateDescriptorNextWeek))]
        NextWeek,
        /// <summary>
        /// Return comics published this month
        /// </summary>
        [StringValue(nameof(MarvelApiResources.DateDescriptorThisMonth))]
        ThisMonth
    }
}
