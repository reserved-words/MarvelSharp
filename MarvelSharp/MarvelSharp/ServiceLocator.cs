using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Parsers;
using MarvelSharp.Services;
using MarvelSharp.Utilities;

namespace MarvelSharp
{
    internal static class ServiceLocator
    {
        internal static IHasher Hasher => new MD5Hasher();
        internal static IHttpService HttpService => new HttpService();
        internal static IParser<Character> CharacterParser => new CharacterParser();
        internal static IParser<Comic> ComicParser => new ComicParser();
        internal static IParser<Creator> CreatorParser => new CreatorParser();
        internal static IParser<Series> SeriesParser => new SeriesParser();
        internal static IParser<Story> StoryParser => new StoryParser();
        internal static IParser<Event> EventParser => new EventParser();
        internal static IUrlBuilder UrlBuilder => new UrlBuilder(Hasher);
    }
}
