using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests
{
    public static class TestJson
    {
        public static string Get(string filename)
        {
            return File.ReadAllText(string.Format(@"{0}\..\..\TestJson\{1}.json", AppDomain.CurrentDomain.BaseDirectory, filename));
        }
    }
}
