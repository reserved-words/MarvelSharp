﻿using MarvelSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Parsers
{
    internal class EventParser : BaseParser<Event>
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
                Modified = ParseDate(result.modified),
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
