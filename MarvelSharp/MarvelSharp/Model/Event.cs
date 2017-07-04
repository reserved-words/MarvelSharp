using System;
using System.Collections.Generic;

namespace MarvelSharp.Model
{
    public class Event : ItemBase
    {
        /// <summary>
        /// The title of the event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A set of public web site URLs for the event.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// The date of publication of the first issue in this event.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// The date of publication of the last issue in this event.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// A resource list containing the comics in this event.
        /// </summary>
        public ItemCollection Comics { get; set; }

        /// <summary>
        /// A resource list containing the stories in this event.
        /// </summary>
        public ItemCollection Stories { get; set; }

        /// <summary>
        /// A resource list containing the series in this event.
        /// </summary>
        public ItemCollection Series { get; set; }

        /// <summary>
        /// A resource list containing the characters which appear in this event.
        /// </summary>
        public ItemCollection Characters { get; set; }

        /// <summary>
        /// A resource list containing creators whose work appears in this event.
        /// </summary>
        public ItemCollection Creators { get; set; }

        /// <summary>
        /// A summary representation of the event which follows this event.
        /// </summary>
        public ItemSummary Next { get; set; }

        /// <summary>
        /// A summary representation of the event which preceded this event.
        /// </summary>
        public ItemSummary Previous { get; set; }

        public override string ToString() => Title;
    }
}
