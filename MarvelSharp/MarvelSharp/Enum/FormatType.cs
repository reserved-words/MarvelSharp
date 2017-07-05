using MarvelSharp.Internal.Attributes;
using static MarvelSharp.MarvelApiResources;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    /// <summary>
    /// Comic format type options
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Comic format type
        /// </summary>
        [StringValue(nameof(FormatTypeComic))]
        Comic,
        /// <summary>
        /// Collection format type
        /// </summary>
        [StringValue(nameof(FormatTypeCollection))]
        Collection
    }
}
