
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Parsers
{
	public class EventParser : BaseParser<Event>
    {
        public override Event Parse(dynamic result)
        {
            return new Event
            {
                Id = result.id,
                Title = result.title,
                Description = result.description,
                ResourceUri = result.resourceUri,
                Urls = ParseUrls(result.urls),
                Modified = ParseDateOffset(result.modified),
                Start = ParseDate(result.start),
                End = ParseDate(result.end),
                Thumbnail = ParseImage(result.thumbnail),
                Comics = ParseItemCollection(result.comics),
                Stories = ParseItemCollection(result.stories, true),
                Series = ParseItemCollection(result.series),
                Characters = ParseItemCollection(result.characters),
                Creators = ParseItemCollection(result.creators, false, true),
                Next = ParseItem(result.next),
                Previous = ParseItem(result.previous)
            };
        }
    }
}
