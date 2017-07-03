using System;

// ReSharper disable once CheckNamespace
namespace MarvelSharp
{
    public class DateItem
    {
        /// <summary>
        /// A description of the date (e.g. onsale date, FOC date).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The date.
        /// </summary>
        public DateTimeOffset? Date { get; set; }
    }
}
