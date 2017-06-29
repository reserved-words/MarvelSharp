using System;
using System.IO;

namespace MarvelSharp.Tests.Unit.Helpers
{
    public static class TestJson
    {
        public static string Get(string filename)
        {
            return File.ReadAllText(string.Format(@"{0}\..\..\TestJson\{1}.json", AppDomain.CurrentDomain.BaseDirectory, filename));
        }
    }
}
