using System.Collections.Generic;

namespace MarvelSharp.Model
{
    public class Creator : ItemBase
    {
        /// <summary>
        /// The first name of the creator.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The middle name of the creator.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The last name of the creator.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The suffix or honorific for the creator.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// The full name of the creator (a space-separated concatenation of the above four fields).
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// A resource list containing the comics which feature work by this creator.
        /// </summary>
        public ItemCollection Comics { get; set; }

        /// <summary>
        /// A resource list containing the series which feature work by this creator.
        /// </summary>
        public ItemCollection Series { get; set; }

        /// <summary>
        /// A resource list containing the stories which feature work by this creator.
        /// </summary>
        public ItemCollection Stories { get; set; }

        /// <summary>
        /// A resource list containing the events which feature work by this creator.
        /// </summary>
        public ItemCollection Events { get; set; }

        /// <summary>
        /// A set of public web site URLs for the resource.
        /// </summary>
        public List<Url> Urls { get; set; }

        public override string ToString() => FullName;
    }
}
