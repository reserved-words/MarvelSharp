﻿
using MarvelSharp.Model;

namespace MarvelSharp.Internal.Parsers
{
    internal class SeriesParser : BaseParser<Series>
    {
        public override Series Parse(dynamic result)
        {
            return new Series
            {
                Id = result.id,
                Title = result.title,
                Description = result.description,
                ResourceUri = result.resourceURI,
                Urls = ParseUrls(result.urls),
                StartYear = result.startYear,
                EndYear = result.endYear,
                Rating = result.rating,
                Type = result.type,
                Modified = ParseDateOffset(result.modified),
                Thumbnail = ParseImage(result.thumbnail),
                Comics = ParseItemCollection(result.comics),
                Stories = ParseItemCollection(result.stories, true),
                Events = ParseItemCollection(result.events),
                Characters = ParseItemCollection(result.characters),
                Creators = ParseItemCollection(result.creators, false, true),
                Next = ParseItem(result.next),
                Previous = ParseItem(result.previous)
            };
        }
    }
}
