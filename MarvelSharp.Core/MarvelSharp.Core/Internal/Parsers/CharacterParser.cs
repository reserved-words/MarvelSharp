
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Parsers
{
    internal class CharacterParser : BaseParser<Character>
    {
        public override Character Parse(dynamic result)
        {
            return new Character
            {
                Id = result.id,
                Name = result.name,
                Description = result.description,
                Modified = ParseDateOffset(result.modified),
                Thumbnail = ParseImage(result.thumbnail),
                ResourceUri = result.resourceURI,
                Urls = ParseUrls(result.urls),
                Comics = ParseItemCollection(result.comics),
                Series = ParseItemCollection(result.series),
                Stories = ParseItemCollection(result.stories, true),
                Events = ParseItemCollection(result.events)
            };
        }
    }
}
