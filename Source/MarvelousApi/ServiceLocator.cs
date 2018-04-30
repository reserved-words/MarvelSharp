using MarvelousApi.Internal.Interfaces;
using MarvelousApi.Internal.Parsers;
using MarvelousApi.Internal.Services;
using MarvelousApi.Internal.Utilities;
using MarvelousApi.Model;

namespace MarvelousApi
{
    public static class ServiceLocator
    {
        // Utilities
        public static IDateProvider DateProvider => new DateProvider();
        public static IHasher Hasher => new MD5Hasher();
        public static IHttpService HttpService => new HttpService();
        public static IUrlBuilder UrlBuilder => new UrlBuilder(Hasher, DateProvider);

        // Parsers
        public static IParser<Character> CharacterParser => new CharacterParser();
        public static IParser<Comic> ComicParser => new ComicParser();
        public static IParser<Creator> CreatorParser => new CreatorParser();
        public static IParser<Series> SeriesParser => new SeriesParser();
        public static IParser<Story> StoryParser => new StoryParser();
        public static IParser<Event> EventParser => new EventParser();

        // Services
        public static CharacterService GetCharacterService(string apiPublicKey, string apiPrivateKey)
        {
            return new CharacterService(HttpService, CharacterParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static ComicService GetComicService(string apiPublicKey, string apiPrivateKey)
        {
            return new ComicService(HttpService, ComicParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static CreatorService GetCreatorService(string apiPublicKey, string apiPrivateKey)
        {
            return new CreatorService(HttpService, CreatorParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        public static EventService GetEventService(string apiPublicKey, string apiPrivateKey)
        {
            return new EventService(HttpService, EventParser, UrlBuilder, apiPublicKey, apiPrivateKey);
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
