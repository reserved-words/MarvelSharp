using System;

namespace MarvelousApi.Model
{
    public class ItemBase
    {
        /// <summary>
        /// The unique ID of the resource.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The date the resource was most recently modified.
        /// </summary>
        public DateTimeOffset? Modified { get; set; }

        /// <summary>
        /// The canonical URL identifier for this resource.
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// The representative image for this resource.
        /// </summary>
        public Image Thumbnail { get; set; }
    }
}
