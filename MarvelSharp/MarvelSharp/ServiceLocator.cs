using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Internal.Parsers;
using MarvelSharp.Internal.Services;
using MarvelSharp.Internal.Utilities;
using MarvelSharp.Model;

namespace MarvelSharp
{
    internal static class ServiceLocator
    {
        // Utilities
        internal static IDateProvider DateProvider => new DateProvider();
        internal static IHasher Hasher => new MD5Hasher();
        internal static IHttpService HttpService => new HttpService();
        internal static IUrlBuilder UrlBuilder => new UrlBuilder(Hasher, DateProvider);

        // Parsers
        internal static IParser<Character> CharacterParser => new CharacterParser();
        internal static IParser<Comic> ComicParser => new ComicParser();
        internal static IParser<Creator> CreatorParser => new CreatorParser();
        internal static IParser<Series> SeriesParser => new SeriesParser();
        internal static IParser<Story> StoryParser => new StoryParser();
        internal static IParser<Event> EventParser => new EventParser();

        // Services
        internal static CharacterService GetCharacterService(string apiPublicKey, string apiPrivateKey)
        {
            return new CharacterService(HttpService, CharacterParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        internal static ComicService GetComicService(string apiPublicKey, string apiPrivateKey)
        {
            return new ComicService(HttpService, ComicParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        internal static CreatorService GetCreatorService(string apiPublicKey, string apiPrivateKey)
        {
            return new CreatorService(HttpService, CreatorParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        internal static EventService GetEventService(string apiPublicKey, string apiPrivateKey)
        {
            return new EventService(HttpService, EventParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        internal static SeriesService GetSeriesService(string apiPublicKey, string apiPrivateKey)
        {
            return new SeriesService(HttpService, SeriesParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }

        internal static StoryService GetStoryService(string apiPublicKey, string apiPrivateKey)
        {
            return new StoryService(HttpService, StoryParser, UrlBuilder, apiPublicKey, apiPrivateKey);
        }
    }
}
