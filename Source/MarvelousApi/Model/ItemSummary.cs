
namespace MarvelousApi.Model
{
    public class ItemSummary
    {
        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The path to the individual resource.
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Story summaries only: The type of the story (interior or cover).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Creator summaries only: The role of the creator in the parent entity.
        /// </summary>
        public string Role { get; set; }
    }
}
