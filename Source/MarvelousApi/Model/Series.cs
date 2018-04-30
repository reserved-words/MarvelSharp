using System.Collections.Generic;

namespace MarvelousApi.Model
{
    public class Series : ItemBase
    {
        /// <summary>
        /// The canonical title of the series.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description of the series.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public List<Url> Urls { get; set; }

        /// <summary>
        /// The first year of publication for the series.
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// The last year of publication for the series (conventionally, 2099 for ongoing series) .
        /// </summary>
        public int? EndYear { get; set; }

        /// <summary>
        /// The age-appropriateness rating for the series.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// The type of the series.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A resource list containing comics in this series.
        /// </summary>
        public ItemCollection Comics { get; set; }

        /// <summary>
        /// A resource list containing stories which occur in comics in this series.
        /// </summary>
        public ItemCollection Stories { get; set; }

        /// <summary>
        /// A resource list containing events which take place in comics in this series.
        /// </summary>
        public ItemCollection Events { get; set; }

        /// <summary>
        /// A resource list containing characters which appear in comics in this series.
        /// </summary>
        public ItemCollection Characters { get; set; }

        /// <summary>
        /// A resource list of creators whose work appears in comics in this series.
        /// </summary>
        public ItemCollection Creators { get; set; }

        /// <summary>
        /// A summary representation of the series which follows this series.
        /// </summary>
        public ItemSummary Next { get; set; }

        /// <summary>
        /// A summary representation of the series which preceded this series.
        /// </summary>
        public ItemSummary Previous { get; set; }

        /// <summary>
        /// Returns a string identifying the Series object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Title;
    }
}
