using MarvelousApi.Internal.Attributes;

// ReSharper disable once CheckNamespace
namespace MarvelousApi.Enum
{
    /// <summary>
    /// Comic format type options
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Comic format type
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatTypeComic))]
        Comic,
        /// <summary>
        /// Collection format type
        /// </summary>
        [StringValue(nameof(MarvelApiResources.FormatTypeCollection))]
        Collection
    }
}
