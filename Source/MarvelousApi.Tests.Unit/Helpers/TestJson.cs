using System.IO;

namespace MarvelousApi.Tests.Unit.Helpers
{
    public static class TestJson
    {
        public static string Get(string filename)
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestJson", $"{filename}.json"));
        }
    }
}
