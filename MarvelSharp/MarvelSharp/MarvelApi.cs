using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp
{
    public static class MarvelApi
    {
        public static string Base = "https://gateway.marvel.com";

        public static string GetAllCharacters = "/v1/public/characters";
        public static string GetCharacter = "/v1/public/characters/{0}";
        public static string GetCharacterComics = "/v1/public/characters/{0}/comics";
        public static string GetCharacterEvents = "/v1/public/characters/{0}/events";
        public static string GetCharacterSeries = "/v1/public/characters/{0}/series";
        public static string GetCharacterStories = "/v1/public/characters/{0}/stories";

        public static string GetAllComics = "/v1/public/comics";
        public static string GetComic = "/v1/public/comics/{0}";
        public static string GetComicCharacters = "/v1/public/comics/{0}/characters";
        public static string GetComicCreators = "/v1/public/comics/{0}/creators";
        public static string GetComicEvents = "/v1/public/comics/{0}/events";
        public static string GetComicStories = "/v1/public/comics/{0}/stories";

        public static string GetAllCreators = "/v1/public/creators";
        public static string GetCreator = "/v1/public/creators/{0}";
        public static string GetCreatorComics = "/v1/public/creators/{0}/comics";
        public static string GetCreatorEvents = "/v1/public/creators/{0}/events";
        public static string GetCreatorSeries = "/v1/public/creators/{0}/series";
        public static string GetCreatorStories = "/v1/public/creators/{0}/stories";

        public static string GetAllEvents = "/v1/public/events";
        public static string GetEvent = "/v1/public/events/{0}";
        public static string GetEventCharacters = "/v1/public/events/{0}/characters";
        public static string GetEventCreators = "/v1/public/events/{0}/creators";
        public static string GetEventSeries = "/v1/public/events/{0}/series";
        public static string GetEventStories = "/v1/public/events/{0}/stories";

        public static string GetAllSeries = "/v1/public/series";
        public static string GetSeries = "/v1/public/series/{0}";
        public static string GetSeriesCharacters = "/v1/public/series/{0}/characters";
        public static string GetSeriesComics = "/v1/public/series/{0}/comics";
        public static string GetSeriesCreators = "/v1/public/series/{0}/creators";
        public static string GetSeriesEvents = "/v1/public/series/{0}/events";
        public static string GetSeriesStories = "/v1/public/series/{0}/stories";

        public static string GetAllStories = "/v1/public/stories";
        public static string GetStory = "/v1/public/stories/{0}";
        public static string GetStoryCharacters = "/v1/public/stories/{0}/characters";
        public static string GetStoryComics = "/v1/public/stories/{0}/comics";
        public static string GetStoryCreators = "/v1/public/stories/{0}/creators";
        public static string GetStoryEvents = "/v1/public/stories/{0}/events";
        public static string GetStorySeries = "/v1/public/stories/{0}/series";

        public static int SuccessCode = 200;
    }
}
