
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Parsers
{
	public class StoryParser : BaseParser<Story>
    {
        public override Story Parse(dynamic result)
        {
            return new Story
            {
                Id = result.id,
                Title = result.title,
                Description = result.description,
                ResourceUri = result.resourceURI,
                Type = result.type,
                Modified = ParseDateOffset(result.modified),
                Thumbnail = ParseImage(result.thumbnail),
                Comics = ParseItemCollection(result.comics),
                Series = ParseItemCollection(result.series),
                Events = ParseItemCollection(result.events),
                Characters = ParseItemCollection(result.characters),
                Creators = ParseItemCollection(result.creators, false, true),
                OriginalIssue = ParseItem(result.originalIssue)
            };
        }
    }
}
