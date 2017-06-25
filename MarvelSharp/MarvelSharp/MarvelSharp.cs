using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parsers;
using MarvelSharp.Services;
using MarvelSharp.Utilities;

namespace MarvelSharp
{
    public static class MarvelSharp
    {
        private static IHttpService HttpService = new HttpService();
        private static IParser<Character> CharacterParser = new CharacterParser();
        private static IParser<Comic> ComicParser = new ComicParser();
        private static IParser<Creator> CreatorParser = new CreatorParser();
        private static IParser<Series> SeriesParser = new SeriesParser();
        private static IParser<Story> StoryParser = new StoryParser();
        private static IParser<Event> EventParser = new EventParser();
        private static IUrlBuilder UrlBuilder = new UrlBuilder(new MD5Hasher());

        public static CharacterService GetCharacterService(string apiPublicKey, string apiPrivateKey)
        {
            return new CharacterService(HttpService, CharacterParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static ComicService GetComicService(string apiPublicKey, string apiPrivateKey)
        {
            return new ComicService(HttpService, ComicParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static EventService GetEventService(string apiPublicKey, string apiPrivateKey)
        {
            return new EventService(HttpService, EventParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static CreatorService GetCreatorService(string apiPublicKey, string apiPrivateKey)
        {
            return new CreatorService(HttpService, CreatorParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static SeriesService GetSeriesService(string apiPublicKey, string apiPrivateKey)
        {
            return new SeriesService(HttpService, SeriesParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static StoryService GetStoryService(string apiPublicKey, string apiPrivateKey)
        {
            return new StoryService(HttpService, StoryParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }
    }
}
