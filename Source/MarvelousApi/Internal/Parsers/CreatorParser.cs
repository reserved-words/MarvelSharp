
using MarvelousApi.Model;

namespace MarvelousApi.Internal.Parsers
{
	public class CreatorParser : BaseParser<Creator>
    {
        public override Creator Parse(dynamic result)
        {
            return new Creator
            {
                Id = result.id,
                FirstName = result.firstName,
                MiddleName = result.middleName,
                LastName = result.lastName,
                Suffix = result.suffix,
                FullName = result.fullName,
                Modified = ParseDateOffset(result.modified),
                ResourceUri = result.resourceURI,
                Urls = ParseUrls(result.urls),
                Thumbnail = ParseImage(result.thumbnail),
                Series = ParseItemCollection(result.series),
                Stories = ParseItemCollection(result.stories, true),
                Comics = ParseItemCollection(result.comics),
                Events = ParseItemCollection(result.events)
            };
        }
    }
}
